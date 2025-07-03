using System;
using Treino1.Model;

namespace Treino1.Repositorios;

public class ProdutosApi
{
    private static List<Produto> produtos = new List<Produto>();
    private static int produtoID = 1;

    public static List<Produto> ObterTodos()
    {
        return produtos;
    } 

    public static Produto ObterPorId (int id)
    {
        return produtos.FirstOrDefault(p => p.Id == id);
    }

    public static Produto Adicionar(Produto produto)
    {
        produto.Id = produtoID++;
        produtos.Add(produto);
        
        return produto;
    }

    public static Produto Atualizar(Produto produto)
    {
        int index = produtos.FindIndex(p=> p.Id == produto.Id);
        if (index != -1)
            produtos[index] = produto;

        return produto;
    }

    public static void Remover (int id)
    {
        Produto produto = ObterPorId(id);

        produtos.Remove(produto);
    }

}
