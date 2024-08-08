// IAR jue 30MAY2024

namespace projBaseDemo.Shared.Interfaces
{
    public interface IResult<T>
    {
        List<string> Messages { get; set; }

        bool Succeeded { get; set; }

        T Data { get; set; }

        //List<ValidationResult> ValidationErrors { get; set; }

        Exception Exception { get; set; }

        int Code { get; set; }
    }
}
