using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace voiceSpend.Dominio.Data;

public class VoiceSpendDbContextFactory : IDesignTimeDbContextFactory<VoiceSpendDbContext>
{
    public VoiceSpendDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<VoiceSpendDbContext>();

        var connectionString = "Server=localhost;Database=voicespend_db;Uid=root;Pwd=root;";

        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        return new VoiceSpendDbContext(optionsBuilder.Options);
    }
}