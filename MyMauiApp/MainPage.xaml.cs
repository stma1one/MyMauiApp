namespace MyMauiApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;// מספר הקלקות על הסתר 
        bool isSwap = false;//האם לשנות כיוון תמונה   
        public MainPage()
        {
            
            InitializeComponent();//קוראת את הזאמל ויוצרת את האובייקטים המתוארים בו
           
        }

        /// <summary>
        /// אירוע הקלקה
        /// </summary>
        /// <param name="sender">מייצג את האובייקט שהפעיל את האירוע</param>
        /// <param name="e">פרמטרים אם היו</param>
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
                    btnHide.Text = "הסתרה";
                }
                count++;
            }
            

        }
        //אירוע אחרי לחיצה על ENTER בווינדוס 
        //או על לחצן השלח במקלדת הוירטואלית באנדרואיד/אייפון
        private void Entry_Completed(object sender, EventArgs e)
        {
            if (entType.Text.Length < 4)
            {
                errorLbl.Text = "סיסמה קצרה מידי";
                errorLbl.IsVisible = true;
                errorLbl.TextColor=Colors.Red;
                errorLbl.HorizontalTextAlignment =TextAlignment.Center;
                entType.Focus();
                entType.CursorPosition = 0;
            }
            else
            {
                errorLbl.Text = string.Empty;
                errorLbl.IsVisible = false;
            }
        }

        /// <summary>
        /// אירוע שינוי טקסט
        /// </summary>
        /// <param name="sender">אובייקט שירה את האירוע</param>
        /// <param name="e">פרמטרים - ערך קודם, ערך חדש</param>
        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblOldPass.Text =$"הטקסט הקודם: {e.OldTextValue}";
        }

        /// <summary>
        /// אירוע לחיצה על כפתור שנה כיוון
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Swap_Clicked(object sender, EventArgs e)
        {
            if (!isSwap)
            {
                //פעולה המבצעת אנימצית רוטציה לאורך זמן בזוית נתונה
                await Imgbot.RotateYTo(180,400,Easing.SpringIn);
            }
            else
            {
                await Imgbot.RotateYTo(0,400);
            }
                isSwap = !isSwap;
        }
    }

}
