using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;

namespace Persistence.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Exemplo> DB_Exemplo { get; set; } //Este objeto relaciona-se a tabela do banco de dados
        public DbSet<User> DB_User { get; set; }
        public DbSet<Hotel> DB_Hotel { get; set; }
        public DbSet<Room> DB_Room { get; set; }
        public DbSet<RoomReserve> DB_RoomReserve { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            Exemplo_ModelCreating(builder);
            User_ModelCreating(builder);
            Hotel_ModelCreating(builder);
            Room_ModelCreating(builder);
            RoomReserve_ModelCreating(builder);
        }

        private void Exemplo_ModelCreating(ModelBuilder builder)
        {
            builder.Entity<Exemplo>().ToTable("Exemplo");//Indica o nome da tabela
            builder.Entity<Exemplo>().HasKey(x => x.ID);//Indicação da chave primária da tabela
            builder.Entity<Exemplo>().Property(x => x.ID).HasColumnName("ID");//Indica o nome da coluna da tabela
            builder.Entity<Exemplo>().Property(x => x.ID).IsRequired();//Torna obrigatório o campo ser preenchido (NOT NULL)
            
            builder.Entity<Exemplo>().Property(x => x.Nome).HasColumnName("Nome");
            builder.Entity<Exemplo>().Property(x => x.Nome).IsRequired();
            builder.Entity<Exemplo>().Property(x => x.Nome).HasMaxLength(200);//Indica o tamanho maximo da coluna da tabela

            builder.Entity<Exemplo>().Property(x => x.Valor).HasColumnName("Valor");
            builder.Entity<Exemplo>().Property(x => x.Valor).IsRequired();

            builder.Entity<Exemplo>().Property(x => x.Ativo).HasColumnName("Ativo");
            builder.Entity<Exemplo>().Property(x => x.Ativo).IsRequired();

            //Cria registro inicias na tabela exemplo
            builder.Entity<Exemplo>()
            .HasData(new List<Exemplo>()
                {
                    new Exemplo(1,"Exemplo 1",10,true),
                    new Exemplo(2,"Exemplo 2",20,false),
                }
            );
        }
        
        private void User_ModelCreating(ModelBuilder builder) {
            builder.Entity<User>().ToTable("User");
            builder.Entity<User>().HasKey(x => x.ID);
            builder.Entity<User>().Property(x => x.ID).HasColumnName("ID");
            builder.Entity<User>().Property(x => x.ID).IsRequired();
            builder.Entity<User>().Property(x => x.Name).HasColumnName("Name");
            builder.Entity<User>().Property(x => x.Name).IsRequired();
            builder.Entity<User>().Property(x => x.Name).HasMaxLength(200);
            builder.Entity<User>().Property(x => x.Email).HasColumnName("Email");
            builder.Entity<User>().Property(x => x.Email).IsRequired();
            builder.Entity<User>().Property(x => x.Password).HasColumnName("Password");
            builder.Entity<User>().Property(x => x.Password).IsRequired();
            builder.Entity<User>().Property(x => x.TypeUser).HasColumnName("TypeUser");
            builder.Entity<User>().Property(x => x.TypeUser).IsRequired();
            builder.Entity<User>().Property(x => x.HotelId).HasColumnName("HotelId");
            builder.Entity<User>().Property(x => x.HotelId).IsRequired(false);

        }

        private void Hotel_ModelCreating(ModelBuilder builder)
        {
            builder.Entity<Hotel>().ToTable("Hotel");
            builder.Entity<Hotel>().HasKey(x => x.ID);
            builder.Entity<Hotel>().Property(x => x.ID).HasColumnName("ID");
            builder.Entity<Hotel>().Property(x => x.ID).IsRequired();
            
            builder.Entity<Hotel>().Property(x => x.Name).HasColumnName("Name");
            builder.Entity<Hotel>().Property(x => x.Name).IsRequired();
            builder.Entity<Hotel>().Property(x => x.Name).HasMaxLength(200);

            builder.Entity<Hotel>().Property(x => x.Descrition).HasColumnName("Descrition");
            builder.Entity<Hotel>().Property(x => x.Descrition).IsRequired();
            builder.Entity<Hotel>().Property(x => x.Descrition).HasMaxLength(400);

            builder.Entity<Hotel>().Property(x => x.CEP).HasColumnName("CEP");
            builder.Entity<Hotel>().Property(x => x.CEP).IsRequired();
            builder.Entity<Hotel>().Property(x => x.CEP).HasMaxLength(10);

            builder.Entity<Hotel>().Property(x => x.CNPJ).HasColumnName("CNPJ");
            builder.Entity<Hotel>().Property(x => x.CNPJ).IsRequired();
            builder.Entity<Hotel>().Property(x => x.CNPJ).HasMaxLength(20);

            builder.Entity<Hotel>().Property(x => x.Address).HasColumnName("Address");
            builder.Entity<Hotel>().Property(x => x.Address).IsRequired();
            builder.Entity<Hotel>().Property(x => x.Address).HasMaxLength(100);
        }

        private void Room_ModelCreating(ModelBuilder builder)
        {
            builder.Entity<Room>().ToTable("Room");
            builder.Entity<Room>().HasKey(x => x.ID);
            builder.Entity<Room>().Property(x => x.ID).HasColumnName("ID");
            builder.Entity<Room>().Property(x => x.ID).IsRequired();
            builder.Entity<Room>().Property(x => x.RoomNumber).HasColumnName("RoomNumber");
            builder.Entity<Room>().Property(x => x.RoomNumber).IsRequired();
            builder.Entity<Room>().Property(x => x.Floor).HasColumnName("floor");
            builder.Entity<Room>().Property(x => x.Floor).IsRequired();
            builder.Entity<Room>().Property(x => x.HotelID).HasColumnName("HotelID");
            builder.Entity<Room>().Property(x => x.HotelID).IsRequired();
            builder.Entity<Room>().Property(x => x.Status).HasColumnName("Status");
            builder.Entity<Room>().Property(x => x.Status).IsRequired();
            builder.Entity<Room>().HasOne(x => x.Hotel).WithMany(x => x.List_Room).HasForeignKey(x => x.HotelID);
        }

        private void RoomReserve_ModelCreating(ModelBuilder builder)
        {
            builder.Entity<RoomReserve>().ToTable("RoomReserve");
            builder.Entity<RoomReserve>().HasKey(x => x.ID);
            builder.Entity<RoomReserve>().Property(x => x.ID).HasColumnName("ID");
            builder.Entity<RoomReserve>().Property(x => x.ID).IsRequired();
            builder.Entity<RoomReserve>().Property(x => x.RoomID).HasColumnName("RoomID");
            builder.Entity<RoomReserve>().Property(x => x.RoomID).IsRequired();
            builder.Entity<RoomReserve>()
                .HasOne(x => x.Room)
                .WithMany(x => x.List_RoomReserve)
                .HasForeignKey(x => x.RoomID);
            builder.Entity<RoomReserve>().Property(x => x.UserID).HasColumnName("UserID");
            builder.Entity<RoomReserve>().Property(x => x.UserID).IsRequired();
            builder.Entity<RoomReserve>()
                .HasOne(x => x.User)
                .WithMany(x => x.List_RoomReserve)
                .HasForeignKey(x => x.UserID);
            builder.Entity<RoomReserve>().Property(x => x.DtStart).HasColumnName("DtStart");
            builder.Entity<RoomReserve>().Property(x => x.DtStart).IsRequired();
            builder.Entity<RoomReserve>().Property(x => x.DtEnd).HasColumnName("DtEnd");
            builder.Entity<RoomReserve>().Property(x => x.DtEnd).IsRequired();
        }
    }
}
