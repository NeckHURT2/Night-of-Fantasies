using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private int vida = 30;

    public void ReceberDano(int dano)
    {
        vida -= dano;
        Debug.Log("Inimigo recebeu dano! Vida restante: " + vida);

        if (vida <= 0)
        {
            Morrer();
        }
    }

    private void Morrer()
    {
        Debug.Log("Inimigo morreu!");
        Destroy(gameObject);
    }
}