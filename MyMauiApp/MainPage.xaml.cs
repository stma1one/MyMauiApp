namespace MyMauiApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
           
        }

        /// <summary>
        /// אירוע הקלקה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHide_Clicked(object sender, EventArgs e)
        { 
            Button button = (Button)sender;//sender as Button
            if (button == btnHide)
            {
                if (count % 2 == 0)
                {
                    lblHide.IsVisible = false;
                    btnHide.Text = "בטל הסתרה";
                }
                else
                {
                    lblHide.IsVisible = true;
                    btnHide.Text = "בטל הסתרה";
                }
                count++;
            }
            

        }

        private void Entry_Completed(object sender, EventArgs e)
        {

        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblOldPass.Text = e.OldTextValue;
        }
    }

}
