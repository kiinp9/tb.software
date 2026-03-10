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
            using var qrGenerator = new QRCodeGenerator();
            using var qrData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);

            var qrCode = new PngByteQRCode(qrData);
            byte[] qrBytes = qrCode.GetGraphic(20);

            using Image<Rgba32> qrImage = Image.Load<Rgba32>(qrBytes);

            int padding = 20;
            Font font = SystemFonts.CreateFont("Arial", 32);

            var lines = textBelow.Split('\n');

            float totalTextHeight = 0;
            float maxTextWidth = 0;

            List<FontRectangle> sizes = new();

            foreach (var line in lines)
            {
                var rect = TextMeasurer.MeasureBounds(line, new TextOptions(font));

                sizes.Add(rect);

                totalTextHeight += rect.Height;

                if (rect.Width > maxTextWidth)
                    maxTextWidth = rect.Width;
            }

            int width = (int)Math.Max(qrImage.Width, maxTextWidth + padding * 2);
            int height = (int)(qrImage.Height + totalTextHeight + padding * 2);

            var finalImage = new Image<Rgba32>(width, height, Color.White);

            finalImage.Mutate(ctx =>
            {
                int qrX = (width - qrImage.Width) / 2;
                ctx.DrawImage(qrImage, new Point(qrX, 0), 1f);

                float currentY = qrImage.Height + padding;

                for (int i = 0; i < lines.Length; i++)
                {
                    float textX = (width - sizes[i].Width) / 2;

                    ctx.DrawText(lines[i], font, Color.Black, new PointF(textX, currentY));

                    currentY += sizes[i].Height;
                }
            });

            MemoryStream ms = new MemoryStream();
            finalImage.SaveAsPng(ms);
            ms.Position = 0;

            return ms;
        }
    }
}
