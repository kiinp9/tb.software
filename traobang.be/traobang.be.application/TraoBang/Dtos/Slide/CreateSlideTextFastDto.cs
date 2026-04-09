namespace traobang.be.application.TraoBang.Dtos.Slide
{
    public class CreateSlideTextFastDto
    {
        private string? _noiDung;

        public int IdSubPlan { get; set; }

        public string? NoiDung { get => _noiDung; set => _noiDung = value?.Trim(); }
        public string? Note { get; set; }
        /// <summary>
        /// Id slide phía trước. Nếu ko truyền thì trong subplan chỉ có 2 slide đầu cuối
        /// </summary>
        public int? IdSlideTruoc { get; set; }

    }
}
