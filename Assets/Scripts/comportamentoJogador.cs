using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class comportamentoJogador : MonoBehaviour
{
    //Variáveis Componentes
    private BoxCollider2D caixaDeColisao;
    private SpriteRenderer spriteR;
    private RaycastHit2D hit;

    //Variáveis Comuns
    private Vector3 movimento;
    [SerializeField] private float velocidade = 2.0f;

    private void Start()
    {
        caixaDeColisao = GetComponent<BoxCollider2D>();
        spriteR = GetComponent<SpriteRenderer>();
    }

    public void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

         //Movimentação(Resetar)
        movimento = new Vector3(x,y,0);

        //Espelhar o Sprite para a direção que apontar, esquerda ou direita
        if (movimento.x > 0)
            spriteR.flipX = false;
        if (movimento.x < 0)
            spriteR.flipX = true;

        //Detecção de colisão direcional. Caso a caixa retorne nula, podemos nos mover.
        hit = Physics2D.BoxCast(transform.position, caixaDeColisao.size, 0, new Vector2(0, movimento.y), Mathf.Abs(movimento.y * Time.deltaTime), LayerMask.GetMask("colisores", "ativos"));
        if (hit.collider == null)
        {
            //Movimentação
             transform.Translate(0, movimento.y * Time.deltaTime * velocidade, 0);
        }
        
        hit = Physics2D.BoxCast(transform.position, caixaDeColisao.size, 0, new Vector2(movimento.x, 0), Mathf.Abs(movimento.x * Time.deltaTime), LayerMask.GetMask("colisores", "ativos"));
        if (hit.collider == null)
        {
            //Movimentação
             transform.Translate(movimento.x * Time.deltaTime * velocidade, 0, 0);
        }
    }
}
