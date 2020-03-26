namespace assignment1_2
{
    public class DTO
    {
        public string String1 { get; set; }
        public string String2 { get; set; }

        public DTO()
        {

        }

        public DTO(string string1, string string2)
        {
            this.String1 = string1;
            this.String2 = string2;
        }
    }
}