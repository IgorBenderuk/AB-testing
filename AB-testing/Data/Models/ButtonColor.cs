using System.Drawing;

namespace AB_testing.Data.Models
{
    public class ButtonColor :BaseEntity
    {

        public string X_Name { get; set; } = string.Empty;

        public Color Button_Color { get; set; }
        // enum added to stote less data in the db (instead of storing string of hex color it stores only integer )
        // and if necessary find something in bd by int is waymo efficient

    }
}
