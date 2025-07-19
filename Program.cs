
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Configurações
const string apiKey = "AMO-TE-2025"; // Chave secreta

var motivos = new List<string> {
    "Teu sorriso ilumina meus dias mais rabugentos rsrs",
    "A forma como você me entende, me deixa sem palavras",
    "Adora quando você se empolga falando, fico tão feliz!",
    "Admiro sua tragetoria, e como se tornou esse Diamente 💎",
    "Gosto como você é tão detalhista e cuidadosa comigo sempre 😌",
    "Nem todos os presentes do mundo se equipara te-lá ao meu lado",
    "Pessoas destinadas sempre se encontram",
    "Passamos por muita coisa juntos, Amor, mas é só o começo!",
};

//Banco de Dados
#region

var memorias = new Dictionary<int, Memory>
{
    [1] = new(
        Data: "03/02/2024",
        Local: "Primeiro Enconto",
        Descricao: "Primeiro Encontro: O dia que tive uma conexão quase instantânea, com a pessoa que veria chamar de namorada, a única!",
        ImagemUrl: "https://i.ibb.co/JW1nyVfW/Primeiro-Encontro.jpg"
    ),
    [2] = new(
        Data: "10/02/2024",
        Local: "Rei Leão",
        Descricao: "Depois de ficarmos perdidos e acharmos o passeio a tempo, passamos um calor absurdo e fomos para a peça do Rei Leão - você sorriu o tempo todo comigo 💕",
        ImagemUrl: "https://i.ibb.co/PvxsSDwJ/20240310-155757.jpg"
    ),
    [3] = new(
        Data: "24/02/2024",
        Local: "Hopi Hari",
        Descricao: "A aventura na Montezum onde você me viu passando sustos no carrinho da frente enquanto você desistia na última hora 😂",
        ImagemUrl: "https://i.ibb.co/Xw6Pdrn/Hopi-Hari.jpg"
    ),
    [4] = new(
        Data: "19/04/2025",
        Local: "Tour Paulista",
        Descricao: "Do Lammer ao Bacio di Latte, onde você brincou sobre OnlyFans kkkk, terminando na exposição do Stranger Things - um dia maravilhoso ao seu lado!",
        ImagemUrl: "https://i.ibb.co/zTdpgSFj/Stranger-things.jpg"
    ),
    [5] = new(
        Data: "29/05/2025",
        Local: "Exposição Tim Burton",
        Descricao: "Minha noiva Burtoniana - tão única e linda quanto as criações do seu diretor favorito",
        ImagemUrl: "https://i.ibb.co/9mrjrVwP/Estranho-Mundo-de-Jack.jpg"
    ),
    [6] = new(
        Data: "28/06/2024",
        Local: "Corujão",
        Descricao: "Nossa loucura noturna com capas, hambúrgueres ruins no BK e aquela foto que ainda é meu wallpaper 😍",
        ImagemUrl: "https://i.ibb.co/7xk630JC/Coruj-o.jpg"
    ),
    [7] = new(
        Data: "20/07/2024",
        Local: "Campos do Jordão",
        Descricao: "O dia que você foi com três anéis e voltou com o quarto... O início oficial do nosso namoro!",
        ImagemUrl: "https://i.ibb.co/dsMxLm0m/Campos-do-Jord-o.jpg"
    ),
    [8] = new(
        Data: "07/09/2025",
        Local: "Harry Potter",
        Descricao: "Minha eterna fã de Harry Potter - cada momento contigo é como uma poção mágica de felicidade",
        ImagemUrl: "https://i.ibb.co/mCPBM4RZ/Harry-Potter.jpg"
    ),
    [9] = new(
        Data: "18/07/2024",
        Local: "Formatura",
        Descricao: "Te procurando na plateia toda para fotos e conseguindo aquelas poses... inesquecíveis! kkkk",
        ImagemUrl: "https://i.ibb.co/DHBMpRKb/Formatura.jpg"
    ),
    [10] = new(
        Data: "15/09/2024",
        Local: "Show do Linkin Park",
        Descricao: "Realizando seu sonho ao som de 'In the End' - seu sorriso valia mais que mil ingressos 🤘",
        ImagemUrl: "https://i.ibb.co/6kvcsMw/Link-Park.jpg"
    ),
    [11] = new(
        Data: "30/12/2024",
        Local: "Última Pizza do Ano",
        Descricao: "Aquele final de ano com pizza, risadas e planos malucos para o próximo ano juntos!",
        ImagemUrl: "https://i.ibb.co/XxdDbjYx/ltima-pizza-de-2024.jpg"
    ),
    [12] = new(
        Data: "02/02/2025",
        Local: "Primeira Viagem",
        Descricao: "Destino não perfeito, mas tempo ao seu lado que fez tudo brilhar - sua beleza iluminando cada momento 🌞",
        ImagemUrl: "https://i.ibb.co/7NJwqHxX/Balne-rio.jpg"
    ),
    [13] = new(
        Data: "06/02/2025",
        Local: "Trilha Aventura",
        Descricao: "Nossa primeira trilha - cansativa mas recompensadora! Precisamos de mais preparo... e mais água! kkk",
        ImagemUrl: "https://i.ibb.co/ZRhsyy9Z/Bombinhas.jpg"
    ),
    [14] = new(
        Data: "21/02/2025",
        Local: "Aniversário Especial",
        Descricao: "Celebrando você, meu amor verdadeiro - cada ano contigo é um presente",
        ImagemUrl: "https://i.ibb.co/xKDJvXvS/Anivers-rio-do-meu-Amor.jpg"
    )
};
#endregion 


// Endpoint API
app.MapGet("/api/romance", (string key) =>
{
    if (key != apiKey) return Results.Unauthorized();

    var random = new Random();
    return Results.Json(new
    {
        motivo = motivos[random.Next(motivos.Count)],
        memoria = memorias[random.Next(memorias.Count)]
    });
});

// Front-End Integrado
app.MapGet("/", (HttpRequest request) =>
{
    var html = @"
    <!DOCTYPE html>
    <html lang='pt-BR'>
    <head>
        <meta charset='UTF-8'>
        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
        <title>Nosso Amor</title>
        <style>
            body {
                font-family: 'Arial', sans-serif;
                background: linear-gradient(135deg, #ff9a9e 0%, #fad0c4 100%);
                margin: 0;
                padding: 20px;
                color: #333;
                text-align: center;
                min-height: 100vh;
                display: flex;
                flex-direction: column;
                align-items: center;
                justify-content: center;
            }
            .container {
                background: rgba(255, 255, 255, 0.9);
                border-radius: 15px;
                box-shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
                padding: 30px;
                max-width: 600px;
                width: 90%;
            }
            h1 {
                color: #e84393;
                margin-bottom: 30px;
            }
            .card {
                background: white;
                border-radius: 10px;
                padding: 20px;
                margin: 20px 0;
                box-shadow: 0 5px 15px rgba(0, 0, 0, 0.05);
            }
            .motivo {
                font-size: 1.2em;
                font-style: italic;
                color: #e84393;
                margin: 20px 0;
            }
            .imagem-container {
                height: 350px;
                display: flex;
                align-items: center;
                justify-content: center;
                background: #f8f9fa;
                border-radius: 10px;
                margin: 15px 0;
            }
            .memoria-img {
                max-width: 100%;
                max-height: 100%;
                width: auto;
                height: auto;
                border-radius: 8px;
                object-fit: contain;
            }
            @media (max-width: 600px) {
                .imagem-container { height: 250px; }
            }
            button {
                background: #e84393;
                color: white;
                border: none;
                padding: 12px 25px;
                border-radius: 50px;
                font-size: 1em;
                cursor: pointer;
                margin-top: 20px;
                transition: all 0.3s;
            }
            button:hover {
                background: #fd79a8;
                transform: translateY(-3px);
                box-shadow: 0 5px 15px rgba(0, 0, 0, 0.1);
            }
            .data {
                color: #636e72;
                font-size: 0.9em;
                margin-top: 10px;
            }
        </style>
    </head>
    <body>
        <div class='container'>
            <h1>❤️ Nosso Primeiro Ano ❤️</h1>
            
            <div class='card'>
                <h2>Motivo para te Amar</h2>
                <p class='motivo' id='motivo'>Carregando...</p>
            </div>
            
            <div class='card'>
                <h2>Memória Especial</h2>
                <h3 id='memoria-titulo'></h3>
                <p id='memoria-descricao'></p>
                <p class='data' id='memoria-data'></p>
                <img id='memoria-imagem' class='memoria-img' src=''>
            </div>
            
            <button onclick='carregarRomance()'>Nova Surpresa</button>
        </div>

        <script>
            async function carregarRomance() {
                try {
                    const response = await fetch('/api/romance?key=AMO-TE-2025');
                    const data = await response.json();
                    
                    document.getElementById('motivo').textContent = `✨ ${data.motivo} ✨`;
                    document.getElementById('memoria-titulo').textContent = data.memoria.local;
                    document.getElementById('memoria-descricao').textContent = data.memoria.descricao;
                    document.getElementById('memoria-data').textContent = data.memoria.data;
                    document.getElementById('memoria-imagem').src = data.memoria.imagemUrl;
                    
                } catch (error) {
                    console.error('Erro:', error);
                }
            }
            
            // Carrega automaticamente ao abrir
            window.onload = carregarRomance;
        </script>
    </body>
    </html>
    ";

    return Results.Content(html, "text/html");
});

app.Run();

#region
record Memory(string Data, string Local, string Descricao, string ImagemUrl);
#endregion