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

            int padding = 5;
            float lineSpacing = 5;
            float fontSize = 64;
            Font font = SystemFonts.CreateFont("Arial", fontSize, FontStyle.Bold);
            var lines = textBelow.Split('\n');

            // Use font size as fixed line height — reliable across all lines
            float lineHeight = fontSize * 1.2f;
            float totalTextHeight = lines.Length * lineHeight + (lines.Length - 1) * lineSpacing;

            float maxTextWidth = 0;
            List<float> lineWidths = new();
            foreach (var line in lines)
            {
                var size = TextMeasurer.MeasureSize(line, new TextOptions(font));
                lineWidths.Add(size.Width);
                if (size.Width > maxTextWidth)
                    maxTextWidth = size.Width;
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
                    float textX = (width - lineWidths[i]) / 2;
                    ctx.DrawText(lines[i], font, Color.Black, new PointF(textX, currentY));
                    currentY += lineHeight + lineSpacing; // lineHeight advances, lineSpacing adds gap
                }
            });

            MemoryStream ms = new MemoryStream();
            finalImage.SaveAsPng(ms);
            ms.Position = 0;
            return ms;
        }
    }
}
