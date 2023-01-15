using Newtonsoft.Json;

namespace Core.Entities;

public class BaseDto : IDto
{
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}