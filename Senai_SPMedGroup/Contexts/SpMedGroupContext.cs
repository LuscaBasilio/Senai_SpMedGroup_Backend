using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai_SPMedGroup.Domains
{
    public partial class SpMedGroupContext : DbContext
    {
        public SpMedGroupContext()
        {
        }

        public SpMedGroupContext(DbContextOptions<SpMedGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Especializacao> Especializacao { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }
        public virtual DbSet<Progresso> Progresso { get; set; }
        public virtual DbSet<TiposUsuarios> TiposUsuarios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; initial catalog = SENAI_SPMEDGROUP_MANHA;user id = sa; pwd = 132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.ToTable("CONSULTA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataConsulta)
                    .HasColumnName("DATA_CONSULTA")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdMedico).HasColumnName("ID_MEDICO");

                entity.Property(e => e.IdPaciente).HasColumnName("ID_PACIENTE");

                entity.Property(e => e.Observacao)
                    .HasColumnName("OBSERVACAO")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Progresso).HasColumnName("PROGRESSO");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__CONSULTA__ID_MED__4924D839");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK__CONSULTA__ID_PAC__4830B400");

                entity.HasOne(d => d.ProgressoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.Progresso)
                    .HasConstraintName("FK__CONSULTA__PROGRE__4A18FC72");
            });

            modelBuilder.Entity<Especializacao>(entity =>
            {
                entity.ToTable("ESPECIALIZACAO");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__ESPECIAL__E2AB1FF4743F0D60")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medicos>(entity =>
            {
                entity.ToTable("MEDICOS");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("UQ__MEDICOS__91136B91254F387A")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasColumnName("CRM")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Especializacao).HasColumnName("ESPECIALIZACAO");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.EspecializacaoNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.Especializacao)
                    .HasConstraintName("FK__MEDICOS__ESPECIA__4460231C");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.Medicos)
                    .HasForeignKey<Medicos>(d => d.IdUsuario)
                    .HasConstraintName("FK__MEDICOS__ID_USUA__45544755");
            });

            modelBuilder.Entity<Pacientes>(entity =>
            {
                entity.ToTable("PACIENTES");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__PACIENTE__C1F89731EC078619")
                    .IsUnique();

                entity.HasIndex(e => e.Rg)
                    .HasName("UQ__PACIENTE__321537C83BACD92D")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasColumnName("RG")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__PACIENTES__ID_US__408F9238");
            });

            modelBuilder.Entity<Progresso>(entity =>
            {
                entity.ToTable("PROGRESSO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Progresso1)
                    .IsRequired()
                    .HasColumnName("PROGRESSO")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposUsuarios>(entity =>
            {
                entity.ToTable("TIPOS_USUARIOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Tipo)
                    .HasColumnName("TIPO")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIOS__161CF724DD6E04DB")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("DATA_NASCIMENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__USUARIOS__ID_TIP__3BCADD1B");
            });
        }
    }
}
