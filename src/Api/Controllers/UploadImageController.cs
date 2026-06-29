using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/uploadimage")]
public class UploadImageController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        // 1. Verifica se chegou algum arquivo
        if (file == null || file.Length == 0)
        {
            return BadRequest("Nenhuma imagem enviada.");
        }

        // 2. Define a pasta onde vai salvar (wwwroot/uploads)
        var folderName = Path.Combine("wwwroot", "uploads");
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        // Se a pasta não existir, o C# cria ela automaticamente
        if (!Directory.Exists(pathToSave))
        {
            Directory.CreateDirectory(pathToSave);
        }

        // 3. Gera um nome único e seguro para o arquivo (Ex: a8b4-92c1.jpg)
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        var fullPath = Path.Combine(pathToSave, fileName);

        // 4. Salva o arquivo fisicamente na pasta
        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // 5. Retorna o caminho que será salvo no banco de dados do Produto
        var dbPath = $"/uploads/{fileName}";
        
        return Ok(new { url = dbPath });
    }
}