namespace XOGame
{
    public partial class Form1 : Form
    {
        private Button[,] _boxes = new Button[3, 3];
        private bool _isXTurn = true;
        private bool _isStarted = false;
        private int _xScore = 0;
        private int _oScore = 0;

        public Form1()
        {
            InitializeComponent();
            CreateBoxes();
        }

        private void CreateBoxes()
        {
            int buttonSize = 100;
            int leftStart = (this.Width - (buttonSize * 3)) / 2;
            int topStart = (this.ClientSize.Height - (buttonSize * 3)) / 2;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button button = new Button
                    {
                        Width = buttonSize,
                        Height = buttonSize,
                        Location = new Point(j * buttonSize + leftStart, i * buttonSize + topStart),
                        Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold),
                    };
                    button.Click += Box_Click;
                    _boxes[i, j] = button;
                    Controls.Add(button);
                }
            }
        }

        private void Box_Click(object? sender, EventArgs e)
        {
            if (!_isStarted) return;

            var button = sender as Button;

            if (button == null) return;

            if (string.IsNullOrEmpty(button.Text))
            {
                button.Text = _isXTurn ? "X" : "O";
                _isXTurn = !_isXTurn;
                CheckForWinner();
            }
        }

        private void CheckForWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (_boxes[i, 0].Text == "") continue;

                if (_boxes[i, 0].Text == _boxes[i, 1].Text && _boxes[i, 1].Text == _boxes[i, 2].Text)
                {
                    MessageBox.Show("Winner is " + _boxes[i, 0].Text);

                    if (_boxes[i, 0].Text == "X")
                    {
                        _xScore++;
                    }
                    else
                    {
                        _oScore++;
                    }
                    lblOScore.Text = "O: " + _oScore;
                    lblXScore.Text = "X: " + _xScore;

                    Start();
                    return;
                }
            }

            for (int j = 0; j < 3; j++)
            {
                if (_boxes[0, j].Text == "") continue;

                if (_boxes[0, j].Text == _boxes[1, j].Text && _boxes[1, j].Text == _boxes[2, j].Text)
                {
                    MessageBox.Show("Winner is " + _boxes[0, j].Text);

                    if (_boxes[0, j].Text == "X")
                    {
                        _xScore++;
                    }
                    else
                    {
                        _oScore++;
                    }

                    lblOScore.Text = "O: " + _oScore;
                    lblXScore.Text = "X: " + _xScore;
                    Start();
                    return;
                }
            }

            if (_boxes[0, 0].Text == _boxes[1, 1].Text && _boxes[1, 1].Text == _boxes[2, 2].Text)
            {
                if (_boxes[0, 0].Text == "") return;

                MessageBox.Show("Winner is " + _boxes[0, 0].Text);

                if (_boxes[0, 0].Text == "X")
                {
                    _xScore++;
                }
                else
                {
                    _oScore++;
                }

                lblOScore.Text = "O: " + _oScore;
                lblXScore.Text = "X: " + _xScore;

                Start();
                return;
            }

            if (_boxes[0, 2].Text == _boxes[1, 1].Text && _boxes[1, 1].Text == _boxes[2, 0].Text)
            {
                if (_boxes[0, 2].Text == "") return;

                MessageBox.Show("Winner is " + _boxes[0, 2].Text);

                if (_boxes[0, 2].Text == "X")
                {
                    _xScore++;
                }
                else
                {
                    _oScore++;
                }

                lblOScore.Text = "O: " + _oScore;
                lblXScore.Text = "X: " + _xScore;
                Start();
                return;
            }

            CheckForDraw();
        }

        private void CheckForDraw()
        {
            foreach (var box in _boxes)
            {
                if (string.IsNullOrEmpty(box.Text))
                {
                    return;
                }
            }
            MessageBox.Show("It's a draw!");
            Start();
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {            
            btnStartGame.Text = "Restart";
            _isStarted = true;

            foreach (var box in _boxes)
            {
                box.Text = "";
            }
        }

        private void btnStartGame_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Key pressed: " + e.KeyCode);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Timer ticked!");
        }
    }
}
