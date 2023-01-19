namespace DentalOffice.WinFormsUI
{
    public class ByteConverter
    {
        public Bitmap ByteToImage(Byte[] blob)
        {
            MemoryStream mStream = new();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
    }
}
