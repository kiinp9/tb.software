using Microsoft.Extensions.Logging;
using QRCoder;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

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
            // Generate QR PNG bytes
            using var qrGenerator = new QRCodeGenerator();
            using var qrData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new PngByteQRCode(qrData);
            byte[] qrBytes = qrCode.GetGraphic(20);

            using Image<Rgba32> qrImage = Image.Load<Rgba32>(qrBytes);

            int padding = 20;

            var font = SystemFonts.CreateFont("Arial", 32);

            var options = new TextOptions(font)
            {
                HorizontalAlignment = HorizontalAlignment.Center
            };

            var size = TextMeasurer.MeasureSize(textBelow, options);

            int width = Math.Max(qrImage.Width, (int)size.Width + padding * 2);
            int height = qrImage.Height + (int)size.Height + padding * 2;

            var finalImage = new Image<Rgba32>(width, height, Color.White);

            finalImage.Mutate(ctx =>
            {
                int qrX = (width - qrImage.Width) / 2;

                ctx.DrawImage(qrImage, new Point(qrX, 0), 1f);

                ctx.DrawText(
                    textBelow,
                    font,
                    Color.Black,
                    new PointF(width / 2, qrImage.Height + padding)
                );
            });

            MemoryStream ms = new MemoryStream();
            finalImage.SaveAsPng(ms);
            ms.Position = 0;

            return ms;
        }
    }
}
