namespace EventsInNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Button button = new Button();
            button.Text = "Click Me!";
            button.Click += OnButtonClick;

            button.OnClick(15);
        }

        private static void OnButtonClick(object sender, EventArgs eventArgs)
        {
            var button = sender as Button;
            var myEventArgs = eventArgs as MyEventArgs;
            Console.WriteLine(button.Text);
            Console.WriteLine(myEventArgs.Amount);
            Console.WriteLine(myEventArgs.Text);
        }
    }

    class Button
    {
        public event EventHandler Click;

        public string Text { get; set; } = string.Empty;

        public void OnClick(int amount)
        {
            Click?.Invoke(this, new MyEventArgs(amount,"hello"));
        }
    }

    class MyEventArgs : System.EventArgs
    {
        public int Amount { get; set; }
        public string Text { get; set; }
        public MyEventArgs(int amount, string text)
        {
            Amount = amount;
            Text = text;
        }
    }
}
