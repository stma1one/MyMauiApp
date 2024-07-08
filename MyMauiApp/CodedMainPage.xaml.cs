
namespace MyMauiApp;

public partial class CodedMainPage : ContentPage
{
    // הגדרת המשתנים הגלובליים עבור הפקדים שנשתמש בהם בקוד
    private VerticalStackLayout? mainLayout;
    private Label? lblHide ;
    private Button? btnHide;
    private Entry? entType;
    private Label? errorLbl;
    private Label? lblOldPass;
    private Image? Imgbot;

    int count = 0;// מספר הקלקות על הסתר 
    bool isSwap = false;//האם לשנות כיוון תמונה  
    public CodedMainPage()
    {
        InitializeComponent();
        BuildUI();
    }

    private void BuildUI()
    {
        // יצירת מבנה הדף הראשי
        mainLayout = new VerticalStackLayout();
        // כותרת ראשית
        AddPageTitle();
       
        // תווית עם מספר שורות
        AddMultiLineLabel();

        // תווית עם טקסט מעוצב
        AddFormattedLabel();
        

        // קו הפרדה
        mainLayout.Add(new BoxView { Color = Colors.Blue, HeightRequest = 5 });

        // סידור אופקי
        AddHorizontalStackLayout();

        // עוד קו הפרדה
        mainLayout.Add(new BoxView { Color = Colors.Blue, HeightRequest = 5 });

        // חלק הזנת הסיסמה
        AddPasswordLayout();
       
        // הגדרת תוכן הדף
        Content = mainLayout;
        

        // החלת עיצוב מותנה
        ApplyConditionalStyling();
    }

    // כותרת ראשית
    private void AddPageTitle()
    {
        var titleLabel = new Label
        {
            Text = "זוהי כותרת",
            FontAttributes = FontAttributes.Bold,
            FontFamily = "RubikDoodle",
            FontSize = 24,
            HorizontalTextAlignment = TextAlignment.Center
        };
        
    }
    // תווית עם מספר שורות
    private void AddMultiLineLabel()
    {
        var multiLineLabel = new Label
        {
            Text = "זה טקסט של שורה ראשונה\nזה טקסט של שורה שניה",
            HorizontalOptions = LayoutOptions.Center
        };
            mainLayout?.Add(multiLineLabel);

    }

    // תווית עם טקסט מעוצב
    private void AddFormattedLabel()
    {
        var formattedLabel = new Label
        {
            Margin = new Thickness(15),
            HorizontalTextAlignment = TextAlignment.Center,
            LineBreakMode = LineBreakMode.WordWrap,
            MaxLines = 3,
            FormattedText = new FormattedString
            {
                Spans = {
                        new Span { Text = "ספאן מאפשר לשלוט בכל חלק בטקסט " },
                        new Span { Text = " כמו הצבע או", TextColor = Colors.Blue },
                        new Span { Text = "  הגדרות נוספות", FontAttributes = FontAttributes.Bold, TextDecorations = TextDecorations.Underline },
                        new Span { Text = "\n" },
                        new Span { Text = " כיף גדול", FontSize = 20 },
                        new Span { Text = "\uf527", FontFamily = "MaterialSymbolsOutlined", FontSize = 35, TextColor = Color.FromArgb("#43eb34") }
                    }
            }
        };
        mainLayout?.Add(formattedLabel);
    }
    
    // סידור אופקי
    private void AddHorizontalStackLayout()
    {
        var horizontalLayout = new HorizontalStackLayout { HorizontalOptions = LayoutOptions.Center };
        #region תווית להסתרה
        // תווית שניתן להסתיר
        lblHide = new Label
        {
            Text = "קוקו! איפה אני?",
            VerticalOptions = LayoutOptions.Center
        };
        #endregion
        horizontalLayout.Add(lblHide);
        // כפתור להסתרת התווית
        #region הגדרת כפתור
        btnHide = new Button
        {
            Text = "הסתרה",
            ImageSource = "eye_crossed.png",
            Margin = new Thickness(10),
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
        btnHide.Clicked += BtnHide_Clicked;
        #endregion
        horizontalLayout.Add(btnHide);
        //הוספה לפריסה הראשית
        mainLayout?.Add(horizontalLayout);
    }

    // חלק הזנת הסיסמה
    private void AddPasswordLayout()
    {
        var passwordLayout = new VerticalStackLayout();
        #region  הוספת תווית סיסמה
        passwordLayout.Add(new Label
        {
            Text = "סיסמה",
            Margin = new Thickness(15, 10, 0, 0),
            HorizontalOptions = LayoutOptions.Center
        });
        #endregion
        // שדה הזנת סיסמה
        #region שדה סיסמה
        entType = new Entry
        {
            IsPassword = true,
            ReturnType = ReturnType.Done,
            WidthRequest = 300
        };

        #region קישור האירועים
        entType.Completed += Entry_Completed;
        entType.TextChanged += Entry_TextChanged;
        #endregion
        passwordLayout.Add(entType);
        #endregion
        // תווית שגיאה (מוסתרת בהתחלה)
        #region תווית שגיאה
        errorLbl = new Label { IsVisible = false };
        passwordLayout.Add(errorLbl);
        #endregion
        // תווית להצגת הסיסמה הישנה
        #region סיסמה ישנה
        lblOldPass = new Label { HorizontalOptions = LayoutOptions.Center };
        passwordLayout.Add(lblOldPass);
        #endregion
        // תמונה
        #region הוספת תמונה
        Imgbot = new Image
        {
            Source = "dotnet_bot.png",
            Aspect = Aspect.AspectFit
        };
        passwordLayout.Add(Imgbot);
        #endregion
        // כפתור החלפה
        #region  הוספת כפתור סיבוב תמונה
        var swapButton = new Button
        {
            Text = "Swap",
            FontFamily = "Pacifico",
            FontSize = 20,
            TextColor = Color.FromArgb("#43eb34"),
            CornerRadius = 60,
            HeightRequest = 120,
            WidthRequest = 120
        };
        swapButton.Clicked += Swap_Clicked;
        passwordLayout.Add(swapButton);
        #endregion

        //הוספה לפריסה הראשית
        mainLayout?.Add(passwordLayout);

    }

    // פונקציה להחלת עיצוב מותנה לפי סוג המכשיר ומערכת ההפעלה
    private void ApplyConditionalStyling()
    {
        if (DeviceInfo.Idiom == DeviceIdiom.Tablet)
        {
            if(Imgbot!=null) 
            Imgbot.Margin = new Thickness(-70);
        }

        if (DeviceInfo.Platform == DevicePlatform.WinUI)
        {
            if (Imgbot != null)
            {
                Imgbot.HeightRequest = 300;
                Imgbot.WidthRequest = 300;
            }
        }
    }

    /// <summary>
    /// אירוע הקלקה
    /// </summary>
    /// <param name="sender">מייצג את האובייקט שהפעיל את האירוע</param>
    /// <param name="e">פרמטרים אם היו</param>
    private void BtnHide_Clicked(object? sender, EventArgs e)
    {
        Button? button = sender as Button;
        if (button == btnHide)
        {
            if (lblHide != null && btnHide != null)
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
    private void Entry_Completed(object? sender, EventArgs e)
    {
        if (entType != null && entType.Text.Length < 4)
        {
            if (errorLbl != null)
            {
                errorLbl.Text = "סיסמה קצרה מידי";
                errorLbl.IsVisible = true;
                errorLbl.TextColor = Colors.Red;
                errorLbl.HorizontalTextAlignment = TextAlignment.Center;
            }
                entType.Focus();
                entType.CursorPosition = 0;
            
        }
        else
        {
            if (errorLbl != null)
            {
                errorLbl.Text = string.Empty;
                errorLbl.IsVisible = false;
            }
        }
    }

    /// <summary>
    /// אירוע שינוי טקסט
    /// </summary>
    /// <param name="sender">אובייקט שירה את האירוע</param>
    /// <param name="e">פרמטרים - ערך קודם, ערך חדש</param>
    private void Entry_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(lblOldPass!=null)
        lblOldPass.Text = $"הטקסט הקודם: {e.OldTextValue}";
    }

    /// <summary>
    /// אירוע לחיצה על כפתור שנה כיוון
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void Swap_Clicked(object? sender, EventArgs e)
    {
        if(Imgbot!=null)
        if (!isSwap)
        {
            //פעולה המבצעת אנימצית רוטציה לאורך זמן בזוית נתונה
            await Imgbot.RotateYTo(180, 400, Easing.SpringIn);
        }
        else
        {
            await Imgbot.RotateYTo(0, 400);
        }
        isSwap = !isSwap;
    }
}