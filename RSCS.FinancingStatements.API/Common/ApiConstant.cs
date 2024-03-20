namespace RSCS.FinancingStatements.API.Common
{
    public class ApiConstant
    {
       // public static IConfiguration Configuration { get; set; }

        public const string Read = "FullAccess,ReadOnly,ReadWrite";//Configuration.GetSection("Roles:FullAccess").ToString();
        public const string Write = "ReadWrite,FullAccess";
        public const string FullAccess = "FullAccess";
        public const string InvoiceAccess = "InvoiceAccess";
        public const string ProgramMentainanceAccess = "ProgramMentainanceAccess";
        public const string SecurityAccess = "SecurityAccess";

    }
}
