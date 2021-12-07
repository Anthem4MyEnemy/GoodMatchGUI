using System.Text.RegularExpressions;

namespace GoodMatchGUI
{
    public partial class GoodMatchForm : Form
    {
        public GoodMatchForm()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            lbOutput.Text = "";
            string name1 = tbFirstName.Text;    
            string name2 = tbSecondName.Text;
            bool valid1 = false;
            bool valid2 = false;
            string title = "Invalid";

            if (string.IsNullOrEmpty(name1) || string.IsNullOrEmpty(name2))
            {
                string errorMsg = "Please enter some input.\n Only use alphabetic characters";
                MessageBox.Show(errorMsg, title);
            }

            string message = "Please enter valid name, only use alphabetical characters";

            if (!string.IsNullOrEmpty(name1))
            {
                valid1 = validator(name1);
                if(!valid1)
                {
                    MessageBox.Show(message,title );
                    tbFirstName.Text = "";
                }
                    

            }

            if (!string.IsNullOrEmpty(name2))
            {
                valid2 = validator(name2);
                if (!valid2)
                {
                    MessageBox.Show(message, title);
                    tbSecondName.Text = "";
                }


            }

            if(!string.IsNullOrEmpty(name1) && !string.IsNullOrEmpty(name2) &&valid1 &&valid2)
            {
                Match m = new Match();
                string result =  m.getMatch(name1, name2);
                int percentage;

                int.TryParse(result, out percentage);
                if (percentage >= 80)
                {
                    lbOutput.Text = $"{name1} matches {name2} {percentage}%, good match";
                }
                else
                {
                    lbOutput.Text = lbOutput.Text = $"{name1} matches {name2} {percentage}%";
                }

                tbFirstName.Text = "";
                tbSecondName.Text = "";
            }
        }

        static bool validator(string s)
        {
            if (s != null)
            {
                return Regex.IsMatch(s, @"^[a-zA-Z]+$");

            }
            else return false;
        }

        private void GoodMatchForm_Load(object sender, EventArgs e)
        {
            lbOutput.Text = "";
        }
    }
}