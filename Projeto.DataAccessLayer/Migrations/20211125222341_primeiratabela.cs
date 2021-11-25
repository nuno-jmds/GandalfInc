using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.DataAccessLayer.Migrations
{
    public partial class primeiratabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaProdutos",
                columns: table => new
                {
                    Identificador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaProdutos", x => x.Identificador);
                });

            migrationBuilder.CreateTable(
                name: "DetalheVenda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalheVenda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Identificador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Identificador);
                });

            migrationBuilder.CreateTable(
                name: "Moradas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distrito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Concelho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moradas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Identificador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroFiscal = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    MoradaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telemovel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Identificador);
                    table.ForeignKey(
                        name: "FK_Clientes_Moradas_MoradaId",
                        column: x => x.MoradaId,
                        principalTable: "Moradas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Identificador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pontuacao = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroFiscal = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    MoradaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telemovel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Identificador);
                    table.ForeignKey(
                        name: "FK_Fornecedores_Moradas_MoradaId",
                        column: x => x.MoradaId,
                        principalTable: "Moradas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lojas",
                columns: table => new
                {
                    Identificador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Gerente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroFiscal = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    MoradaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telemovel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lojas", x => x.Identificador);
                    table.ForeignKey(
                        name: "FK_Lojas_Moradas_MoradaId",
                        column: x => x.MoradaId,
                        principalTable: "Moradas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Identificador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Fabricante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FornecedorIdentificador = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReferenciaInternacionalProduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroSerie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetalheVendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Identificador);
                    table.ForeignKey(
                        name: "FK_Produtos_DetalheVenda_DetalheVendaId",
                        column: x => x.DetalheVendaId,
                        principalTable: "DetalheVenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produtos_Fornecedores_FornecedorIdentificador",
                        column: x => x.FornecedorIdentificador,
                        principalTable: "Fornecedores",
                        principalColumn: "Identificador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produtos_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PontoDeVenda",
                columns: table => new
                {
                    Identificador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LojaIdentificador = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontoDeVenda", x => x.Identificador);
                    table.ForeignKey(
                        name: "FK_PontoDeVenda_Lojas_LojaIdentificador",
                        column: x => x.LojaIdentificador,
                        principalTable: "Lojas",
                        principalColumn: "Identificador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PontoDeVendaIdentificador = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FuncionarioIdentificador = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClienteIdentificador = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroSerie = table.Column<int>(type: "int", nullable: false),
                    TipoDePagamento = table.Column<int>(type: "int", nullable: false),
                    DetalheVendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venda_Clientes_ClienteIdentificador",
                        column: x => x.ClienteIdentificador,
                        principalTable: "Clientes",
                        principalColumn: "Identificador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Venda_DetalheVenda_DetalheVendaId",
                        column: x => x.DetalheVendaId,
                        principalTable: "DetalheVenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Venda_Funcionario_FuncionarioIdentificador",
                        column: x => x.FuncionarioIdentificador,
                        principalTable: "Funcionario",
                        principalColumn: "Identificador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Venda_PontoDeVenda_PontoDeVendaIdentificador",
                        column: x => x.PontoDeVendaIdentificador,
                        principalTable: "PontoDeVenda",
                        principalColumn: "Identificador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_MoradaId",
                table: "Clientes",
                column: "MoradaId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_MoradaId",
                table: "Fornecedores",
                column: "MoradaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lojas_MoradaId",
                table: "Lojas",
                column: "MoradaId");

            migrationBuilder.CreateIndex(
                name: "IX_PontoDeVenda_LojaIdentificador",
                table: "PontoDeVenda",
                column: "LojaIdentificador");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_DetalheVendaId",
                table: "Produtos",
                column: "DetalheVendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FornecedorIdentificador",
                table: "Produtos",
                column: "FornecedorIdentificador");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_StockId",
                table: "Produtos",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ClienteIdentificador",
                table: "Venda",
                column: "ClienteIdentificador");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_DetalheVendaId",
                table: "Venda",
                column: "DetalheVendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_FuncionarioIdentificador",
                table: "Venda",
                column: "FuncionarioIdentificador");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_PontoDeVendaIdentificador",
                table: "Venda",
                column: "PontoDeVendaIdentificador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaProdutos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "DetalheVenda");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "PontoDeVenda");

            migrationBuilder.DropTable(
                name: "Lojas");

            migrationBuilder.DropTable(
                name: "Moradas");
        }
    }
}
