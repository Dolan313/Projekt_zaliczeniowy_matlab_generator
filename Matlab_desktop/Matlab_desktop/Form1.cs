using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;


namespace Matlab_desktop
{
    public partial class Form1 : Form
    {
        int counter = 0;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        // Wartoœci pocz¹tkowe w okienkach
        public Form1()
        {
            InitializeComponent();
            textBoxMinX.Text = "-10";
            textBoxMaxX.Text = "10";


        }

        // Walidacja danych wejœciowych - upewnienie siê co do poprawnoœci matematycznej i sk³adniowej funkcji
        private bool IsFunctionValid(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return false;

            if (ContainsDivisionByZero(s))
                return false;

            try
            {
                int index = 0;
                return ParseExpression(s, ref index) && index == s.Length;
            }
            catch
            {
                return false;
            }
        }

        private bool ContainsDivisionByZero(string func)
        {
            // Znajdujemy wszystkie dzielenia przez coœ w nawiasach lub bez nawiasów
            // np. 1/0, 5/(2-2), (x+1)/0
            var regex = new System.Text.RegularExpressions.Regex(@"/\s*\(([^\)]+)\)|/\s*([0-9\.\-]+)");
            foreach (System.Text.RegularExpressions.Match m in regex.Matches(func))
            {
                string denom = m.Groups[1].Success ? m.Groups[1].Value : m.Groups[2].Value;

                try
                {
                    // oceniamy mianownik jako wyra¿enie numeryczne
                    var result = new System.Data.DataTable().Compute(denom, null);
                    if (Convert.ToDouble(result) == 0)
                        return true; // dzielenie przez zero
                }
                catch
                {
                    // jeœli nie mo¿na oceniæ jako liczba, ignorujemy (np. /x)
                }
            }
            return false;
        }

        private bool ParseExpression(string s, ref int index)
        {
            if (!ParseTerm(s, ref index))
                return false;

            while (index < s.Length)
            {
                char c = s[index];
                if (c == '+' || c == '-')
                {
                    index++;
                    if (!ParseTerm(s, ref index))
                        return false;
                }
                else
                {
                    break;
                }
            }

            return true;
        }

        private bool ParseTerm(string s, ref int index)
        {
            if (!ParseFactor(s, ref index))
                return false;

            while (index < s.Length)
            {
                char c = s[index];
                if (c == '*' || c == '/')
                {
                    index++;
                    if (!ParseFactor(s, ref index))
                        return false;
                }
                else
                {
                    break;
                }
            }

            return true;
        }

        private bool ParseFactor(string s, ref int index)
        {
            if (index >= s.Length)
                return false;

            // obs³uga potêgi
            int startIndex = index;
            if (!ParsePrimary(s, ref index))
                return false;

            if (index < s.Length && s[index] == '^')
            {
                index++;
                if (!ParseFactor(s, ref index))
                    return false;
            }

            return true;
        }

        private bool ParsePrimary(string s, ref int index)
        {
            // liczby
            if (char.IsDigit(s[index]) || s[index] == '.')
            {
                while (index < s.Length && (char.IsDigit(s[index]) || s[index] == '.'))
                    index++;
                return true;
            }

            // zmienna x
            if (s[index] == 'x')
            {
                index++;
                return true;
            }

            // funkcje
            string[] functions = {
        "sin","cos","tan","cot",
        "asin","acos","atan","acot",
        "sqrt","exp","log","log10","abs"};

            foreach (var f in functions)
            {
                if (s.Substring(index).StartsWith(f))
                {
                    index += f.Length;
                    if (index >= s.Length || s[index] != '(')
                        return false;

                    index++; // pomijamy '('
                    if (!ParseExpression(s, ref index))
                        return false;

                    if (index >= s.Length || s[index] != ')')
                        return false;

                    index++; // pomijamy ')'
                    return true;
                }
            }

            // nawiasy zwyk³e
            if (s[index] == '(')
            {
                index++;
                if (!ParseExpression(s, ref index))
                    return false;
                if (index >= s.Length || s[index] != ')')
                    return false;
                index++;
                return true;
            }

            return false;
        }


        // Generowanie wykresu
        private async void buttonGenerate_Click(object sender, EventArgs e)
        {
            counter++;
            string userFunction = funkcja.Text.Trim();

            // walidacja funkcji
            if (!IsFunctionValid(userFunction))
            {
                MessageBox.Show("Podana funkcja jest niepoprawna. SprawdŸ sk³adniê.");
                return;
            }

            userFunction = Regex.Replace(userFunction, @"(?<=[^\.\s])(\^|\*|/)", m => "." + m.Value);

            double xMin = double.TryParse(textBoxMinX.Text, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out var xm) ? xm : -10;
            double xMax = double.TryParse(textBoxMaxX.Text, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out var xM) ? xM : 10;

            if (xMin >= xMax)
            {
                MessageBox.Show("XMin musi byæ mniejsze od XMax");
                return;
            }

            string imageFileName = $"wykres_{counter}.png";
            string imagePath = Path.Combine(Path.GetTempPath(), imageFileName);
            imagePath = imagePath.Replace(@"\", @"\\"); // MATLAB wymaga podwójnych backslashy


            wykres.Image = Image.FromFile("C:\\Users\\tomas\\Tomasz\\Techniki informatyczne\\Projekt\\Matlab_desktop\\Matlab_desktop\\loading3.gif");
            wykres.SizeMode = PictureBoxSizeMode.CenterImage;
            generuj.Enabled = false;

            string matlabCommand =
    $"x={xMin}:0.01:{xMax}; y={userFunction}; fig=figure('Visible','off'); plot(x,y); exportgraphics(fig,'{imagePath}','Resolution',150); close(fig);";

            var psi = new ProcessStartInfo
            {
                FileName = @"C:\Program Files\MATLAB\R2025b\bin\matlab.exe",
                Arguments = $"-batch \"{matlabCommand}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };


            await Task.Run(() =>
            {
                using (var process = Process.Start(psi))
                {
                    process.WaitForExit();
                }
            });


            if (File.Exists(imagePath))
            {
                wykres.Image = Image.FromFile(imagePath);
                wykres.SizeMode = PictureBoxSizeMode.Zoom; // dopasowanie do PictureBox
            }
            else
            {
                wykres.Image = null;
                MessageBox.Show("Nie znaleziono pliku wykresu");
            }

            generuj.Enabled = true; // odblokowanie przycisku
        }

        // Obliczanie pochodnej
        private void pochodnaFunkcji_Click_1(object sender, EventArgs e)
        {
            string userFunction = funkcja.Text.Trim();

            // walidacja funkcji
            if (!IsFunctionValid(userFunction))
            {
                MessageBox.Show("Podana funkcja jest niepoprawna. SprawdŸ sk³adniê.");
                return;
            }

            userFunction = Regex.Replace(userFunction, @"(?<=[^\.\s])(\^|\*|/)", m => "." + m.Value);

            string matlabCommand =
                $"syms x; f = {userFunction}; df = diff(f); disp(char(df));";

            var psi = new ProcessStartInfo
            {
                FileName = @"C:\Program Files\MATLAB\R2025b\bin\matlab.exe",
                Arguments = $"-nosplash -nodesktop -batch \"{matlabCommand}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (var proc = Process.Start(psi))
            {
                string output = proc.StandardOutput.ReadToEnd();
                proc.WaitForExit();

                // wyci¹gniêcie ostatniej linii – MATLAB wypisze tam wynik pochodnej
                string[] lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string derivative = lines.Length > 0 ? lines[lines.Length - 1] : "";

                pochodna.Text = derivative;
            }
        }

        // Obliczanie miejsc zerowych
        private void miejscaZeroweButton_Click(object sender, EventArgs e)
        {
            string userFunction = funkcja.Text.Trim();

            // walidacja funkcji
            if (!IsFunctionValid(userFunction))
            {
                MessageBox.Show("Podana funkcja jest niepoprawna. SprawdŸ sk³adniê.");
                return;
            }

            userFunction = Regex.Replace(userFunction, @"(?<=[^\.\s])(\^|\*|/)", m => "." + m.Value);


            if (string.IsNullOrWhiteSpace(userFunction))
            {
                miejscaZerowe.Text = "Brak funkcji.";
                return;
            }

            if (!double.TryParse(min_od.Text, out double minVal) ||
                !double.TryParse(max_do.Text, out double maxVal))
            {
                miejscaZerowe.Text = "Niepoprawny przedzia³.";
                return;
            }

            // Wektoryzacja operatorów dla MATLAB
            userFunction = System.Text.RegularExpressions.Regex.Replace(
                userFunction, @"(?<=[^\.\s])(\^|\*|/)", m => "." + m.Value);

            miejscaZerowe.Multiline = true;

            // MATLAB command z metod¹ fminbnd
            string matlabCommand =
                "f=@(x)" + userFunction + ";" +
                "a=" + minVal.ToString(System.Globalization.CultureInfo.InvariantCulture) + ";" +
                "b=" + maxVal.ToString(System.Globalization.CultureInfo.InvariantCulture) + ";" +
                "Z=[];" +
                // wykrywanie minimum |f(x)| w przedziale
                "try " +
                "x_min=fminbnd(@(x) abs(f(x)), a, b);" +
                "if abs(f(x_min))<=1e-12, Z=[Z; x_min]; end;" +
                "end;" +
                // wykrywanie zmian znaku
                "Y=linspace(a,b,2000); FY=f(Y);" +
                "idx=find(FY(1:end-1).*FY(2:end)<0);" +
                "if ~isempty(idx), Z=[Z; arrayfun(@(k) fzero(f,[Y(k),Y(k+1)]), idx(:))]; end;" +
                "Z=unique(round(Z,12));" +
                "if isempty(Z), fprintf('NO_ZEROS\\n'); else for i=1:length(Z), fprintf('x%d = %.12g\\n',i,Z(i)); end; end;";

            var psi = new ProcessStartInfo
            {
                FileName = @"C:\Program Files\MATLAB\R2025b\bin\matlab.exe", // dostosuj œcie¿kê
                Arguments = $"-batch \"{matlabCommand}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            try
            {
                using (var proc = new Process())
                {
                    proc.StartInfo = psi;
                    proc.Start();

                    string stdout = proc.StandardOutput.ReadToEnd();
                    string stderr = proc.StandardError.ReadToEnd();

                    proc.WaitForExit();

                    if (!string.IsNullOrWhiteSpace(stderr))
                    {
                        miejscaZerowe.Text = "B³¹d MATLAB: " + stderr.Trim();
                        return;
                    }

                    if (stdout.Contains("NO_ZEROS"))
                    {
                        miejscaZerowe.Text = $"Brak miejsc zerowych funkcji w przedziale [{minVal}, {maxVal}].";
                        return;
                    }

                    miejscaZerowe.Text = stdout.Trim();
                }
            }
            catch (Exception ex)
            {
                miejscaZerowe.Text = "B³¹d uruchomienia MATLAB: " + ex.Message;
            }
        }

        // Usuwanie wykresów po zakoñczeniu dzia³ania programu
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            var files = Directory.GetFiles(Path.GetTempPath(), "wykres_*.png");
            foreach (var file in files)
            {
                try { File.Delete(file); } catch { }
            }
            base.OnFormClosed(e);
        }


        // Funkcjonalnoœci okna aplikacji
        private void btnCloseClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnMinimizeClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
