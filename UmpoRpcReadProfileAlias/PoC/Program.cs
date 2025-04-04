using System;
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

                sbyte [] someBytes = new sbyte[1];
                int someInt = 0;

                // Make the RPC call
                var result = client.UmpoRpcReadProfileAlias(
                    null,
                    ref someBytes,
                    1001337,
                    out someInt
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
