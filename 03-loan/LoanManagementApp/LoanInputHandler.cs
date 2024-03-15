namespace LoanManagementApp;

public class LoanInputHandler
{
    private string[] args;

    public LoanInputHandler(String[] args) {
        this.args = args;
    }

     public double getPrincipal() {
        return double.Parse(args[0]);
     }
}
