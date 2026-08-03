using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Web_Api_29_07_Mine.Models;

namespace Web_Api_29_07_Mine.Context
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Mundos
            modelBuilder.Entity<Mundo>().HasData(
                new Mundo { Id = 1, Nome = "Survival", Bioma = "Plains" },
                new Mundo { Id = 2, Nome = "Creative", Bioma = "Forest" },
                new Mundo { Id = 3, Nome = "Hardcore", Bioma = "Desert" }
            );

            // Players
            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = 1,
                    Nickname = "Steve",
                    Nivel = 35,
                    MundoId = 1,
                    Uuid = "uuid-steve",
                    SkinUrl = "https://crafatar.com/avatars/Steve"
                },

                new Player
                {
                    Id = 2,
                    Nickname = "Alex",
                    Nivel = 18,
                    MundoId = 2,
                    Uuid = "uuid-alex",
                    SkinUrl = "https://crafatar.com/avatars/Alex"
                }
            );

            // Itens
            modelBuilder.Entity<Item>().HasData(

                new Item
                {
                    Id = 1,
                    Nome = "Diamond Sword",
                    Tipo = "Weapon",
                    ImagemUrl = "https://minecraft.wiki/images/Diamond_Sword.png"
                },

                new Item
                {
                    Id = 2,
                    Nome = "Diamond Pickaxe",
                    Tipo = "Tool",
                    ImagemUrl = "https://minecraft.wiki/images/Diamond_Pickaxe.png"
                },

                new Item
                {
                    Id = 3,
                    Nome = "Golden Apple",
                    Tipo = "Food",
                    ImagemUrl = "https://minecraft.wiki/images/Golden_Apple.png"
                }
            );

            // Inventário
            modelBuilder.Entity<Inventario>().HasData(

                new Inventario
                {
                    PlayerId = 1,
                    ItemId = 1,
                    Quantidade = 1
                },

                new Inventario
                {
                    PlayerId = 1,
                    ItemId = 2,
                    Quantidade = 1
                },

                new Inventario
                {
                    PlayerId = 2,
                    ItemId = 3,
                    Quantidade = 5
                }
            );

            // Blocos
            modelBuilder.Entity<Bloco>().HasData(

                new Bloco
                {
                    Id = 1,
                    Nome = "Diamond Block",
                    Tipo = "Mineral",
                    Resistencia = 5,
                    Empilhavel = true
                },

                new Bloco
                {
                    Id = 2,
                    Nome = "Stone",
                    Tipo = "Natural",
                    Resistencia = 1.5,
                    Empilhavel = true
                }
            );

            // Mobs
            modelBuilder.Entity<Mob>().HasData(

                new Mob
                {
                    Id = 1,
                    Nome = "Creeper",
                    Hostil = true,
                    Vida = 20,
                    Drop = "Gunpowder",
                    Bioma = "Plains"
                },

                new Mob
                {
                    Id = 2,
                    Nome = "Zombie",
                    Hostil = true,
                    Vida = 20,
                    Drop = "Rotten Flesh",
                    Bioma = "Forest"
                },

                new Mob
                {
                    Id = 3,
                    Nome = "Cow",
                    Hostil = false,
                    Vida = 10,
                    Drop = "Leather",
                    Bioma = "Plains"
                }
            );

            // Biomas
            modelBuilder.Entity<Bioma>().HasData(

                new Bioma
                {
                    Id = 1,
                    Nome = "Plains",
                    Temperatura = 0.8,
                    Chove = true
                },

                new Bioma
                {
                    Id = 2,
                    Nome = "Desert",
                    Temperatura = 2.0,
                    Chove = false
                },

                new Bioma
                {
                    Id = 3,
                    Nome = "Forest",
                    Temperatura = 0.7,
                    Chove = true
                }
            );

            // Encantamentos
            modelBuilder.Entity<Encantamento>().HasData(

                new Encantamento
                {
                    Id = 1,
                    Nome = "Sharpness",
                    NivelMaximo = 5,
                    Categoria = "Sword",
                    Descricao = "Aumenta o dano da espada."
                },

                new Encantamento
                {
                    Id = 2,
                    Nome = "Efficiency",
                    NivelMaximo = 5,
                    Categoria = "Tool",
                    Descricao = "Aumenta a velocidade de mineração."
                },

                new Encantamento
                {
                    Id = 3,
                    Nome = "Fortune",
                    NivelMaximo = 3,
                    Categoria = "Pickaxe",
                    Descricao = "Aumenta a quantidade de drops."
                }
            );
        }
    }
}