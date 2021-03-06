// <auto-generated />
using Flyturismo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Flyturismo.Migrations
{
    [DbContext(typeof(TurismoContext))]
    partial class TurismoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Flyturismo.Models.Cliente", b =>
                {
                    b.Property<int>("Id_Cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CPF")
                        .HasColumnType("int");

                    b.Property<int>("DestinoId_destino")
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HospedagemId_hospedagem")
                        .HasColumnType("int");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Cliente");

                    b.HasIndex("DestinoId_destino");

                    b.HasIndex("HospedagemId_hospedagem");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Flyturismo.Models.Destino", b =>
                {
                    b.Property<int>("Id_Destino")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Destino");

                    b.ToTable("Destinos");
                });

            modelBuilder.Entity("Flyturismo.Models.Hospedagem", b =>
                {
                    b.Property<int>("Id_Hospedagem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Data_Entrada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Data_Saida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo_Hospedagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Hospedagem");

                    b.ToTable("Hospedagens");
                });

            modelBuilder.Entity("Flyturismo.Models.Cliente", b =>
                {
                    b.HasOne("Flyturismo.Models.Destino", "Destino")
                        .WithMany()
                        .HasForeignKey("DestinoId_destino")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Flyturismo.Models.Hospedagem", "Hospedagem")
                        .WithMany()
                        .HasForeignKey("HospedagemId_hospedagem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destino");

                    b.Navigation("Hospedagem");
                });
#pragma warning restore 612, 618
        }
    }
}
