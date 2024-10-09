namespace BlazorMulitpleFormApp.Models;

public class Step1Data
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }

    public bool IsValid { get; set; }
}


public class Step2Data
{
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;

    public bool IsValid { get; set; }
}

public class Step3Data
{
    public string Company { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;

    public bool IsValid { get; set; }
}

public class Step4Data
{
    public string Comments { get; set; } = string.Empty;

    public bool IsValid { get; set; }
}
