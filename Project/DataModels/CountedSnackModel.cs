using System.Diagnostics;
using System.Xml.Linq;

public class CountedSnackModel
{
    
    public SnackModel Snack { get; set; }
    public int Quantity { get; set;  }

    public CountedSnackModel(SnackModel snack, int quantity)
    {
        Snack = snack;
        Quantity = quantity;
    }
    public override string ToString()
    {
        return $"Snack: {Snack.Name} | Quantity: {Quantity}";
    }
}




