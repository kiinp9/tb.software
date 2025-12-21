namespace traobang.be.application.TraoBang.Dtos
{
    public class GetListPlanResponseDto
    {
        public int Id { get; set; }
        public string Ten { get; set; } = string.Empty;
        /// <summary>
        /// <see cref="TrangThaiPlan"/>
        /// </summary>
        public int TrangThai { get; set; }
    }
}
