using paraMvc.Data.Enums;
using paraMvc.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using paraMvc.Data.Static;

namespace paraMvc.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>(); context.Database.EnsureCreated();

                context.Database.EnsureCreated();
                //product
                if (!context.Product.Any())
                {
                    context.Product.AddRange(new List<Product>()
                    {
                        new Product()
                        { Name = "BIO-OIL HUILE ANTI-VERGETURES 25 ML",
                            Description = "La formule de Bio-Oil combine des extraits de plantes et de vitamines en suspension dans une base d’huile. Elle contient l’ingrédient révolutionnaire PurCellin OilMC, qui modifie la consistance globale de la formule en la rendant légère et non grasse. ",
                            Price = 139.50,
                            ImageURL = "data:image/jpeg;base64,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",
                            ProductCategory = Category.Visage

                        },
                        new Product()
                        {
                            Name = "BIODERMA SENSIBIO FORTE CRÈME 40ML",
                            Description = "Soin apaisant rapide pour les peaux intolérantes qui souffre de rougeurs et de surchauffe : rougeurs (frottement après une irritation, feu de rasoir, épilation, peelings...), surchauffe après une opération dermatologique (Post-laser), coups de soleil ",
                            Price = 159.50,
                            ImageURL = "data:image/jpeg;base64,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",
                            ProductCategory = Category.Corps
                        },
                        new Product()
                        {
                             Name = "DOUCELIA SÉRUM CHEVEUX RÉPARATEUR ET PROTECTEUR 60ML",
                            Description = " Le sérum cheveux de notre gamme Doucelia  est à base d’huile d’argan, huile d’amande douce et huile de jojoba.",
                            Price = 100.50,
                            ImageURL = "data:image/jpeg;base64,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",
                            ProductCategory = Category.Cheveux
                        }

                    });
                    context.SaveChanges();
                }
                // fournisseur
                if (!context.Fournisseur.Any())
                {
                    context.Fournisseur.AddRange(new List<Fournisseur>()
                    {
                        new Fournisseur()
                        {
                            FullName = "fournis1",
                            ProfilePictureURL="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAIoAAACKCAMAAABCWSJWAAAAbFBMVEX5+vxAPz3///8sKSjGxsf8/f89PDo5ODZBPj37+/s2NTIyMS8uLSs7Ojff39/Y2NjQ0NB9fX2fn57y8/S8vLzo6emTkpInJyRdXFptbWxSUlBycnGsrKwbGRSMjIxLS0oAAAAhIB1lZWQkISLKzhSKAAAEXklEQVR4nO2b23KbMBBAYW1JgLiLewkU8v//WGGc2kmxjZCWZKach3Ta6cOZ1Wol7RLLOjg4ODg4ODgwDiEgcS3Lnf4k5PtMwAqzom56Su2mLrJQ/sP3eLhhWjmcs4BKAsa5U6Whu7cNsQjECfOpfcVxpp+Bz5IYdl4mCJN3Zi/A3pNw18BA2/MlkSk+vG/3CwyxupLazgMVm5adu5MLyatHIbnCq3wXF2niPTexbW8XFyLGlyYyLqPAd4F6hYl0+YW+j6A9rTGx7VOL7AKRv87Etv0I18WtFwvbEqx2MU0g8x6Uk39xeIYZFnDoa4cPFeogqkD0ttpE8oaYLW6yOlMmWIJmQnIVkQm0mgvZ6p0846MlLnQvjsGv8A5NpQrUVGiFpEKEmoikF0gq4fqi8hGWECdvSaS0lSdYhKQSr7oe3OF4MZaKalQQVX5OVH5QrijXfbzK7/aKu5n2WLcnWH+Fm2Fod21IVY9DtKs2WX/HnjkhZe10CFVKyUIrpCPImlZI6ZbAU7QLJXHFbxWV3wKxowCJQsH1EszHB4nWJwulaEl7QWE/l3iZcsEVay+VwYi3fWZINKxTGfC7gytfILgP5iukLV+bnNpdmnGQvnTBTtmbS8ue7mnKsDtOdy5xwOmjvq3DabxjPxtEd3pwd2F+JwC13/QF4kYjXzgEGK+jvVrZEzD18ME612U5Jc1lpeQPGpRlHVswjUX2WSEC52RqJxECIksaryx9zv2y5E2SidkySs57uECeeNxuxTSdI+CKMG7TokjbOBRTQKShaG3udTm2jAyJzeVqnJrWmkctl+nhZXI4/020zVR2OMUOjCiukzHq90Uk7ieXZFqxqJAS8384FZhtfmKN/FpOHCnDxiLOxUdURB4XI+O34oc5coCw8T5NpCgf/H5MuqLokrH3B35fhB3ba7BOZxL1C2WNBt6FYOEsYD3ORQ5CqtzUCChGXCCyFZuC0xoFtvmONskb1e7KBa8x3Uwg1rrh2L+B8WrLrAvpfGf1+OWTin3qjKpAti0mF4xec0nuK7dsb1DfYLqIUbkLdw8z9ySCdtAxkW8iU3fdDQ31r5iqdErtg2UMNRUgVhoYLmNmjChG7fWRK2Qic+G8cvL/nFL/Ukdc1dHYMkHl6j6OyFlxXvgIrh0W95dWdbvBEs2SS0ID22fmTXN4B4Wh9ZErVGitkLwwGdjJM5q9bTgPpkx097OBmn9Dr/q7Bk1sSjWeaMrfQzxH52sJ6AwVlRmmsYcU5z+v0NhDJFzRoVXB31zlIDOsUm5OFuVPZ16h8WlNbTRVZLLUW00MZ61O3v4gFcvErfaTyrjVBNS+yHvN9lMI1kx+VNi+mUn4fNiiDNv+jiedyZNZlhWNk9loWKin09wwmi2lXj8B0sGUyaA5TyRu6hnZ0cxLtUdWcK7edTOGsqEyMQghbpb0/KQB75PMzBSPgJXHZw3i3DI42CR/J1Ab+Mbfdjs4ODg4ODg4ODj4z/kD6GhBLxH6lHcAAAAASUVORK5CYII=",
                            Telephone = "0987654334"


                        },
                        new Fournisseur()
                        {
                            FullName = "fourni2",
                            ProfilePictureURL="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAIoAAACKCAMAAABCWSJWAAAAbFBMVEX5+vxAPz3///8sKSjGxsf8/f89PDo5ODZBPj37+/s2NTIyMS8uLSs7Ojff39/Y2NjQ0NB9fX2fn57y8/S8vLzo6emTkpInJyRdXFptbWxSUlBycnGsrKwbGRSMjIxLS0oAAAAhIB1lZWQkISLKzhSKAAAEXklEQVR4nO2b23KbMBBAYW1JgLiLewkU8v//WGGc2kmxjZCWZKach3Ta6cOZ1Wol7RLLOjg4ODg4ODgwDiEgcS3Lnf4k5PtMwAqzom56Su2mLrJQ/sP3eLhhWjmcs4BKAsa5U6Whu7cNsQjECfOpfcVxpp+Bz5IYdl4mCJN3Zi/A3pNw18BA2/MlkSk+vG/3CwyxupLazgMVm5adu5MLyatHIbnCq3wXF2niPTexbW8XFyLGlyYyLqPAd4F6hYl0+YW+j6A9rTGx7VOL7AKRv87Etv0I18WtFwvbEqx2MU0g8x6Uk39xeIYZFnDoa4cPFeogqkD0ttpE8oaYLW6yOlMmWIJmQnIVkQm0mgvZ6p0846MlLnQvjsGv8A5NpQrUVGiFpEKEmoikF0gq4fqi8hGWECdvSaS0lSdYhKQSr7oe3OF4MZaKalQQVX5OVH5QrijXfbzK7/aKu5n2WLcnWH+Fm2Fod21IVY9DtKs2WX/HnjkhZe10CFVKyUIrpCPImlZI6ZbAU7QLJXHFbxWV3wKxowCJQsH1EszHB4nWJwulaEl7QWE/l3iZcsEVay+VwYi3fWZINKxTGfC7gytfILgP5iukLV+bnNpdmnGQvnTBTtmbS8ue7mnKsDtOdy5xwOmjvq3DabxjPxtEd3pwd2F+JwC13/QF4kYjXzgEGK+jvVrZEzD18ME612U5Jc1lpeQPGpRlHVswjUX2WSEC52RqJxECIksaryx9zv2y5E2SidkySs57uECeeNxuxTSdI+CKMG7TokjbOBRTQKShaG3udTm2jAyJzeVqnJrWmkctl+nhZXI4/020zVR2OMUOjCiukzHq90Uk7ieXZFqxqJAS8384FZhtfmKN/FpOHCnDxiLOxUdURB4XI+O34oc5coCw8T5NpCgf/H5MuqLokrH3B35fhB3ba7BOZxL1C2WNBt6FYOEsYD3ORQ5CqtzUCChGXCCyFZuC0xoFtvmONskb1e7KBa8x3Uwg1rrh2L+B8WrLrAvpfGf1+OWTin3qjKpAti0mF4xec0nuK7dsb1DfYLqIUbkLdw8z9ySCdtAxkW8iU3fdDQ31r5iqdErtg2UMNRUgVhoYLmNmjChG7fWRK2Qic+G8cvL/nFL/Ukdc1dHYMkHl6j6OyFlxXvgIrh0W95dWdbvBEs2SS0ID22fmTXN4B4Wh9ZErVGitkLwwGdjJM5q9bTgPpkx097OBmn9Dr/q7Bk1sSjWeaMrfQzxH52sJ6AwVlRmmsYcU5z+v0NhDJFzRoVXB31zlIDOsUm5OFuVPZ16h8WlNbTRVZLLUW00MZ61O3v4gFcvErfaTyrjVBNS+yHvN9lMI1kx+VNi+mUn4fNiiDNv+jiedyZNZlhWNk9loWKin09wwmi2lXj8B0sGUyaA5TyRu6hnZ0cxLtUdWcK7edTOGsqEyMQghbpb0/KQB75PMzBSPgJXHZw3i3DI42CR/J1Ab+Mbfdjs4ODg4ODg4ODj4z/kD6GhBLxH6lHcAAAAASUVORK5CYII=",
                            Telephone = "088333"
                        },
                        new Fournisseur()
                        {
                             FullName = "fourni3",
                            ProfilePictureURL="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAIoAAACKCAMAAABCWSJWAAAAbFBMVEX5+vxAPz3///8sKSjGxsf8/f89PDo5ODZBPj37+/s2NTIyMS8uLSs7Ojff39/Y2NjQ0NB9fX2fn57y8/S8vLzo6emTkpInJyRdXFptbWxSUlBycnGsrKwbGRSMjIxLS0oAAAAhIB1lZWQkISLKzhSKAAAEXklEQVR4nO2b23KbMBBAYW1JgLiLewkU8v//WGGc2kmxjZCWZKach3Ta6cOZ1Wol7RLLOjg4ODg4ODgwDiEgcS3Lnf4k5PtMwAqzom56Su2mLrJQ/sP3eLhhWjmcs4BKAsa5U6Whu7cNsQjECfOpfcVxpp+Bz5IYdl4mCJN3Zi/A3pNw18BA2/MlkSk+vG/3CwyxupLazgMVm5adu5MLyatHIbnCq3wXF2niPTexbW8XFyLGlyYyLqPAd4F6hYl0+YW+j6A9rTGx7VOL7AKRv87Etv0I18WtFwvbEqx2MU0g8x6Uk39xeIYZFnDoa4cPFeogqkD0ttpE8oaYLW6yOlMmWIJmQnIVkQm0mgvZ6p0846MlLnQvjsGv8A5NpQrUVGiFpEKEmoikF0gq4fqi8hGWECdvSaS0lSdYhKQSr7oe3OF4MZaKalQQVX5OVH5QrijXfbzK7/aKu5n2WLcnWH+Fm2Fod21IVY9DtKs2WX/HnjkhZe10CFVKyUIrpCPImlZI6ZbAU7QLJXHFbxWV3wKxowCJQsH1EszHB4nWJwulaEl7QWE/l3iZcsEVay+VwYi3fWZINKxTGfC7gytfILgP5iukLV+bnNpdmnGQvnTBTtmbS8ue7mnKsDtOdy5xwOmjvq3DabxjPxtEd3pwd2F+JwC13/QF4kYjXzgEGK+jvVrZEzD18ME612U5Jc1lpeQPGpRlHVswjUX2WSEC52RqJxECIksaryx9zv2y5E2SidkySs57uECeeNxuxTSdI+CKMG7TokjbOBRTQKShaG3udTm2jAyJzeVqnJrWmkctl+nhZXI4/020zVR2OMUOjCiukzHq90Uk7ieXZFqxqJAS8384FZhtfmKN/FpOHCnDxiLOxUdURB4XI+O34oc5coCw8T5NpCgf/H5MuqLokrH3B35fhB3ba7BOZxL1C2WNBt6FYOEsYD3ORQ5CqtzUCChGXCCyFZuC0xoFtvmONskb1e7KBa8x3Uwg1rrh2L+B8WrLrAvpfGf1+OWTin3qjKpAti0mF4xec0nuK7dsb1DfYLqIUbkLdw8z9ySCdtAxkW8iU3fdDQ31r5iqdErtg2UMNRUgVhoYLmNmjChG7fWRK2Qic+G8cvL/nFL/Ukdc1dHYMkHl6j6OyFlxXvgIrh0W95dWdbvBEs2SS0ID22fmTXN4B4Wh9ZErVGitkLwwGdjJM5q9bTgPpkx097OBmn9Dr/q7Bk1sSjWeaMrfQzxH52sJ6AwVlRmmsYcU5z+v0NhDJFzRoVXB31zlIDOsUm5OFuVPZ16h8WlNbTRVZLLUW00MZ61O3v4gFcvErfaTyrjVBNS+yHvN9lMI1kx+VNi+mUn4fNiiDNv+jiedyZNZlhWNk9loWKin09wwmi2lXj8B0sGUyaA5TyRu6hnZ0cxLtUdWcK7edTOGsqEyMQghbpb0/KQB75PMzBSPgJXHZw3i3DI42CR/J1Ab+Mbfdjs4ODg4ODg4ODj4z/kD6GhBLxH6lHcAAAAASUVORK5CYII=",
                            Telephone = "088765455"
                        }

                    });
                    context.SaveChanges();
                }
                //demandeItems
                //demmande
                if (!context.Demmande.Any())
                {
                    context.Demmande.AddRange(new List<Demmande>()
                    {
                        new Demmande()
                        {
                            date = DateTime.Now,
                           FournisseurId = 1


                        },
                        new Demmande()
                        {
                              date = DateTime.Now,
                           FournisseurId = 2
                        },
                        new Demmande()
                        {
                             date = DateTime.Now,
                           FournisseurId = 3
                        }

                    });
                    context.SaveChanges();
                }

            }


        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@admin.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "admin@admin?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "user@gmail?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
