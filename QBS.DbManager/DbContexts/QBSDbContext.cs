using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QBS.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace QBS.DbManager.DbContexts
{
    public class QBSDbContext: IdentityDbContext<SysUser, SysRole, int,
                                                          SysUserClaim, SysUserRole, SysUserLogin,
                                                          SysRoleClaim, SysUserToken>
    {
        private string? m_ConnectionString;
        public QBSDbContext(QBS.Utility.ConfigService config)
        {
            m_ConnectionString = config.GetConnectionString();
        }

        //public QBSDbContext()
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql(m_ConnectionString);
            optionsBuilder.UseSqlServer(m_ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QBS.Models.System.SysOperation>();
            modelBuilder.Entity<QBS.Models.System.SystemMenu>(entity => {
                entity.Property(c => c.Id).ValueGeneratedOnAdd();
                //映射父子结构
                entity.HasMany(c => c.SubMenus).WithOne(c => c.Parent).HasForeignKey(c => c.ParentID).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<QBS.Models.System.SysMenuOperation>(entity =>
            {
                entity.HasOne(c => c.Menu).WithMany(c => c.SysMenuOperations).HasForeignKey(c => c.MenuID);
                entity.HasOne(c => c.Operation).WithMany(c => c.SysMenuOperations).HasForeignKey(c => c.OperationID);
            });

            modelBuilder.Entity<QBS.Models.System.SysRoleMenu>(entity =>
            {
                entity.HasOne(c => c.SysRole).WithMany(c => c.SysRoleMenus).HasForeignKey(c => c.RoleId);
                entity.HasOne(c => c.Menu).WithMany(c => c.SysRoleMenus).HasForeignKey(c => c.MenuId);
            });

            modelBuilder.Entity<QBS.Models.System.SysRoleMenuOperation>(entity =>
            {
                entity.HasOne(c => c.RoleMenu).WithMany(c => c.SysRoleMenuOperations).HasForeignKey(c => c.SysRoleMenuID);
                entity.HasOne(c => c.Operation).WithMany(c => c.SysRoleMenuOperations).HasForeignKey(c => c.OperationID);
            });

            modelBuilder.Entity<QBS.Models.Normal.NorUserCourse>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.HasOne(c => c.User).WithMany(c => c.UserCourses).HasForeignKey(c => c.UserId);
                entity.HasOne(c => c.Course).WithMany(c => c.UserCourses).HasForeignKey(c => c.CourseId);
            });

            modelBuilder.Entity<QBS.Models.Normal.Course>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).HasMaxLength(50);
                entity.HasOne(c => c.CourseType).WithMany(c => c.Courses).HasForeignKey(c => c.CourseTypeId);
            });

            modelBuilder.Entity<QBS.Models.Normal.KnowledgePoints>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c=>c.Content).HasMaxLength(1050);
                entity.Property(c => c.ExaminationSite).HasMaxLength(250);
                entity.HasOne(c => c.Course).WithMany(c => c.KnowledgePoints).HasForeignKey(c => c.CourseId);
                entity.HasOne(c => c.knowledgePointsRank).WithMany(c => c.KnowledgePoints).HasForeignKey(c => c.RankId);
                entity.HasOne(c => c.knowledgePointsType).WithMany(c => c.KnowledgePoints).HasForeignKey(c => c.TypeId);
            });

            modelBuilder.Entity<QBS.Models.Normal.KnowledgePointsRank>(entity =>
            {
                entity.HasKey(c => c.Id);
            });

            modelBuilder.Entity<QBS.Models.Normal.KnowledgePointsType>(entity =>
            {
                entity.HasKey(c => c.Id);
            });

            modelBuilder.Entity<QBS.Models.Normal.QuestionBank>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).HasMaxLength(55);
                entity.Property(c => c.Content).HasMaxLength(65);
                entity.Property(c => c.Grade).HasMaxLength(5);
                entity.HasOne(c => c.Course).WithMany(c => c.QuestionBanks).HasForeignKey(c => c.CourseId);
            });

            modelBuilder.Entity<QBS.Models.Normal.Question>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Describe).HasMaxLength(550);
                entity.Property(c => c.Difficulty).HasMaxLength(15);
                entity.Property(c => c.Analysis).HasMaxLength(650);
                entity.Property(c => c.Type).HasMaxLength(15);
                entity.HasOne(c => c.QuestionBank).WithMany(c => c.Questions).HasForeignKey(c => c.QuestionBankId);
                entity.HasOne(c=>c.Course).WithMany(c=>c.Questions).HasForeignKey(c=>c.CourseId);
            });

            modelBuilder.Entity<QBS.Models.Normal.Answer>(entity => 
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Content).HasMaxLength(1050);
                entity.HasOne(c => c.Question).WithMany(c => c.Answers).HasForeignKey(c => c.QuestionId);
            });

            modelBuilder.Entity<QBS.Models.Normal.ExaminationPlan>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).HasMaxLength(55);
                entity.Property(c => c.Describe).HasMaxLength(150);
                entity.HasOne(c => c.User).WithMany(c => c.ExaminationPlans).HasForeignKey(c => c.UserId);
            });

            modelBuilder.Entity<QBS.Models.Normal.Test>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).HasMaxLength(55);
                entity.Property(c => c.Edition).HasMaxLength(20);
                entity.Property(c=>c.Status).HasMaxLength(8);
                entity.Property(c => c.Type).HasMaxLength(15);
                entity.HasOne(c => c.ExaminationPlan).WithMany(c => c.Tests).HasForeignKey(c => c.PlanId);
                entity.HasOne(c => c.User).WithMany(c => c.Tests).HasForeignKey(c => c.UserId);
            });

            modelBuilder.Entity<QBS.Models.Normal.TestQuestion>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Describe).HasMaxLength(550);
                entity.Property(c => c.Analysis).HasMaxLength(650);
                entity.Property(c => c.Type).HasMaxLength(15);
                entity.HasOne(c => c.Test).WithMany(c => c.TestQuestions).HasForeignKey(c => c.TestId);
            });

            modelBuilder.Entity<QBS.Models.Normal.TestAnswer>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Content).HasMaxLength(1050);
                entity.HasOne(c => c.TestQuestion).WithMany(c => c.TestAnswers).HasForeignKey(c => c.TestQuestionId);
            });
            this.IdentityModelCreating(modelBuilder);
          
        }

        private void IdentityModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysUser>(b =>
            {
                b.ToTable("TB_SysUser");
                b.HasKey(u => u.Id);
                b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
                //SQL Server下正常，MySQL下报错，如果使用索引，MYSQL下字段长度最大可设置为191
                b.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");
                b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

                b.Property(u => u.UserName).HasMaxLength(256);
                b.Property(u => u.NormalizedUserName).HasMaxLength(128);
                b.Property(u => u.Email).HasMaxLength(256);
                b.Property(u => u.NormalizedEmail).HasMaxLength(128);
                b.Ignore(u => u.LockoutEnd);
                b.Ignore(c => c.LoginPassword);

                b.HasMany<SysUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
                b.HasMany<SysUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
                b.HasMany<SysUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
            });

            modelBuilder.Entity<SysRole>(b =>
            {
                b.HasKey(r => r.Id);
                b.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();
                b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

                b.Property(u => u.Name).HasMaxLength(256);
                b.Property(u => u.NormalizedName).HasMaxLength(128);

                b.HasMany<SysRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
            });


            modelBuilder.Entity<SysUserClaim>(b =>
            {
                b.HasKey(uc => uc.Id);
            });

            modelBuilder.Entity<SysUserRole>(b =>
            {
                b.HasKey(uc => uc.Id);
                b.HasOne(c => c.Role).WithMany(c => c.SysUserRoles).HasForeignKey(c => c.RoleId);
                b.HasOne(c => c.User).WithMany(c => c.SysUserRoles).HasForeignKey(c => c.UserId);
            });

            modelBuilder.Entity<SysUserLogin>(b =>
            {
                b.HasKey(c => c.Id);
            });

            modelBuilder.Entity<SysUserToken>(b =>
            {
                b.HasKey(c => c.Id);
            });

            modelBuilder.Entity<SysRoleClaim>(b =>
            {
                b.HasKey(rc => rc.Id);
            });
        }
    }
}
