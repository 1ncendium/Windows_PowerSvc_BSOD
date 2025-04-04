using System;
using System.Text;
using NtCoreLib.Ndr.Marshal;
using rpc_6c9b7b96_45a8_4cca_9eb3_e21ccf8b5a89_1_1;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            using (Client client = new Client())
            {
                client.Connect("dabrpc");

                sbyte[] someBytes = new sbyte[1];
                NtCoreLib.Ndr.Marshal.NdrEnum16? Complex = null;
                int someInt = 0;
                Guid myguid = Guid.NewGuid();
                // Make the RPC call with the required parameters
                var result = client.UmpoRpcReadFromUserPowerKey(
                    null,
                    myguid,
                    myguid,
                    1001337,
                    1001337,
                    ref someBytes,
                    1001337,
                    out someInt,
                    ref Complex
                );

                Console.WriteLine($"RPC Call Result: {result}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.StackTrace.ToString()}");
        }
        finally
        {
            Console.WriteLine("Execution finished.");
        }
    }
}
