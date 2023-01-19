namespace DentalOffice.WinFormsUI
{
    public class ComboBoxHelper
    {
        public int GetIdFromComboBox(object cmbValue)
        {
            if (int.TryParse(cmbValue.ToString(), out int id))
                return id;

            return -1;
        }
    }
}
