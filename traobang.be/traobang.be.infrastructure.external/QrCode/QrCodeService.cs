using Microsoft.Extensions.Logging;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace traobang.be.infrastructure.external.QrCode
{
    public class QrCodeService : IQrCodeService
    {
        private readonly ILogger _logger;
        public QrCodeService(ILogger<QrCodeService> logger)
        {
            _logger = logger;
        }

        public Stream GenQrCodeByText(string text)
        {
            _logger.LogInformation($"{nameof(GenQrCodeByText)}, text = {text}");

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q)
            )
            using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
            {
                byte[] qrCodeImage = qrCode.GetGraphic(20);
                Stream stream = new MemoryStream(qrCodeImage);
                return stream;
            }
        }

        public Stream GenerateQrWithText(string qrText, string textBelow)
        {
            using QRCodeGenerator qrGenerator = new QRCodeGenerator();
            using QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            using QRCode qrCode = new QRCode(qrCodeData);

            using Bitmap qrImage = qrCode.GetGraphic(20);

            using Font font = new Font("Arial", 32);

            // measure text
            using Bitmap tempBmp = new Bitmap(1, 1);
            using Graphics tempGraphics = Graphics.FromImage(tempBmp);

            SizeF textSize = tempGraphics.MeasureString(textBelow, font);

            int width = Math.Max(qrImage.Width, (int)textSize.Width + 20);
            int textHeight = (int)textSize.Height + 10;
            int height = qrImage.Height + textHeight;

            Bitmap finalImage = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(finalImage))
            {
                g.Clear(Color.White);

                // center QR
                int qrX = (width - qrImage.Width) / 2;
                g.DrawImage(qrImage, qrX, 0);

                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.NoWrap
                };

                Rectangle textRect = new Rectangle(0, qrImage.Height, width, textHeight);

                g.DrawString(textBelow, font, Brushes.Black, textRect, sf);
            }

            MemoryStream ms = new MemoryStream();
            finalImage.Save(ms, ImageFormat.Png);
            ms.Position = 0;

            finalImage.Dispose();

            return ms;
        }
    }
}
