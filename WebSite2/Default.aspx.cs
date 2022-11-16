using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Threading.Tasks;
using System.Web.Configuration;

public partial class _Default : Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string FilePath = WebConfigurationManager.AppSettings["FilePath"];
        try
        {
            // Check if file exists with its full path    
            if (File.Exists(FilePath))
            {
                // If file found, delete it    
                File.Delete(FilePath);
                Console.WriteLine("File deleted.");
            }
            else Console.WriteLine("File not found");
        }
        catch (IOException ioExp)
        {
            Console.WriteLine(ioExp.Message);
        }

    }

    static string ComputeSha256Hash(string rawData)
    {
        // Create a SHA256   
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // ComputeHash - returns byte array  
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            // Convert byte array to a string   
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }

    public class ExportDTO
    {
        public Body body { get; set; }
        public string sha256 { get; set; }
    }

    public class Body
    {
        public string FullName { get; set; }
        public string Sponsor { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string HostName { get; set; }
        public int N_VisitType { get; set; }
        public string Dt_AppointmentStartTime { get; set; }
        public string Dt_AppointmentEndTime { get; set; }
        public int N_DocumentType { get; set; }
        public string S_DocumentNo { get; set; }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string FilePath = WebConfigurationManager.AppSettings["FilePath"];
        Body personDTO = new Body();
        personDTO.FullName = TextBox1.Text;
        personDTO.Sponsor = "Tektronix";
        personDTO.MobileNo = "0521446964";
        personDTO.Email = "saud@tektronixllc.ae";
        personDTO.HostName = "Zubair";
        personDTO.N_VisitType = 2388;
        personDTO.Dt_AppointmentStartTime = "2022-11-07 10:00:00";
        personDTO.Dt_AppointmentEndTime = "2022-11-09 17:00:00";
        personDTO.N_DocumentType = 24;
        personDTO.S_DocumentNo = "784199345767141";
        var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(personDTO);
        var SHA256String = ComputeSha256Hash(jsonString);
        ExportDTO exportDTO = new ExportDTO();
        exportDTO.body = personDTO;
        exportDTO.sha256 = SHA256String;
        var exportString = Newtonsoft.Json.JsonConvert.SerializeObject(exportDTO);
        File.WriteAllText(FilePath, exportString);
    }
}