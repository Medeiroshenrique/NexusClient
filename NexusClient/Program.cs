using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        string serverIP = "127.0.0.1"; // IP do servidor
        int serverPort = 8888; // Porta de comunicação

        TcpClient client = new TcpClient(serverIP, serverPort); // Cria uma instância TcpClient e se conecta ao servidor especificado pelo IP e porta
        NetworkStream stream = client.GetStream(); // Obtém o fluxo de rede para enviar e receber dados

        Console.WriteLine("Escolha uma operação:");
        Console.WriteLine("1-Area de uma casa");
        Console.WriteLine("2-Area de um circulo");
        Console.WriteLine("3-O poder do seu soco no espaço,na velocidade da luz");

        string operacao = Console.ReadLine(); // Lê a operação matemática a ser enviada para o servidor a partir da entrada do usuário


        byte[] buffer = Encoding.ASCII.GetBytes(operacao); // Converte a operação em uma sequência de bytes para ser enviada pela rede
        stream.Write(buffer, 0, buffer.Length); // Envia os bytes para o servidor através do fluxo de rede

        switch (operacao)
        {
            case "1":
                Console.WriteLine("Qual o comprimento da casa?");
                double ComprimentoCasa = double.Parse(Console.ReadLine());
                Console.WriteLine("Qual a largura da casa?");
                double LarguraCasa = double.Parse(Console.ReadLine());
                Console.WriteLine($"A area da casa eh : {ComprimentoCasa*LarguraCasa}");
                break;

            case "2":
                Console.WriteLine("Qual o raio do circulo?");
                double RaioCirculo = double.Parse(Console.ReadLine());
                //float AreaCirculo = (RaioCirculo*RaioCirculo)*3.141592653;
                Console.WriteLine($"A area do circulo eh : {Math.Pow(RaioCirculo,2)*3.141592653}");
                break;

            case "3":
                Console.WriteLine("Qual a massa do seu soco?");
                double MassaSoco = double.Parse(Console.ReadLine());
                Console.WriteLine($"Seu soco teria o poder de {MassaSoco* Math.Pow(299792458,2)} joules, poderia causar uma catastrofe!");
                break;

            case "4":
                Console.WriteLine("Informe o valor principal:");
                double principalSimples = double.Parse(Console.ReadLine());
                Console.Write("Informe a taxa de juros (%): ");
                double taxaJurosSimples = double.Parse(Console.ReadLine());
                Console.Write("Informe o período (em anos): ");
                int periodoSimples = int.Parse(Console.ReadLine());
                Console.WriteLine($"Montante: {principal * Math.Pow(1 + (taxaJuros / 100), periodo)}");
            
            
            case "5": 
                Console.WriteLine("Informe o valor principal:");
                double principalComposto = double.Parse(Console.ReadLine());
                Console.Write("Informe a taxa de juros (%): ");
                double taxaJurosCompostos = double.Parse(Console.ReadLine());
                Console.Write("Informe o período (em anos): ");
                int periodoComposto = int.Parse(Console.ReadLine());
                Console.WriteLine($"Montante: {principalComposto * Math.Pow(1 + (taxaJurosCompostos / 100), periodoComposto}");

            default:
                Console.WriteLine("Operacao invalida!");
                break;
        }

        buffer = new byte[1024]; // Cria um novo buffer para armazenar os dados recebidos do servidor
        int bytesRead = stream.Read(buffer, 0, buffer.Length); // Lê os dados recebidos do servidor para o buffer e retorna o número de bytes lidos
        string result = Encoding.ASCII.GetString(buffer, 0, bytesRead); // Converte os bytes recebidos em uma string contendo o resultado
        Console.WriteLine("Resultado recebido: " + result); // Imprime o resultado recebido na tela

        client.Close(); // Fecha a conexão com o servidor
    }
}
