using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sentence : MonoBehaviour 
{
	//v2.untap.in
	public Text t;
	string text;
	char[] c;
	int i, y;
	Animator anim;
	AudioSource audio;

	void Start () 
	{
		text = "“O total de mortes devido ao uso do tabaco atingiu a cifra de 4,9 milhões de mortes anuais, " +
			"o que corresponde a mais de 10 mil mortes por dia.” - Revista WHO, 2013.\n\n\n “A cada dia, quase 3,9 mil adolescentes experimentam o primeiro cigarro, sendo que metade está destinada a manter o hábito. Desses, quase 30% acabarão morrendo " +
			"vítimas de alguma doença relacionada ao fumo — isso representa 5,6 milhões de jovens, hoje " +
			"com menos de 18 anos, que vão morrer prematuramente por causa do cigarro.” - Dados da OMS";
		c = text.ToCharArray ();
		StartCoroutine (show ());
		anim = t.GetComponent<Animator> ();
		audio = this.gameObject.GetComponent<AudioSource> ();
		this.audio.loop = true;
	}

	void Reset()
	{
		t.text = "";
		if (y==0)
		{
			text = "“Nos últimos dez anos, o tabaco matou 50 milhões de pessoas em todo o mundo”.  - Dados do INCA \n\n\n O Brasil gasta R$ 21 bilhões no tratamento de pacientes com doenças relacionadas ao consumo de cigarros. O valor é 3,5 vezes maior que o imposto arrecadado pela Receita Federal com produtos derivados do tabaco. Também corresponde a 30% de todo o orçamento do SUS.";
		}
		else
		{
			text = "Quando fumamos, prejudicamos a todos em nossa volta. Sua família corre o mesmo risco que você. Diga não ao fumo.";
		}
		c = text.ToCharArray ();
		i = 0;
		StartCoroutine (show ());
		y++;
		audio.mute = false;
	}

	IEnumerator show()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.05f);
			if (i < c.Length)
			{
				t.text += c[i];	i++;
			}
			else
			{
				audio.mute = true;
				yield return new WaitForSeconds(3);
				StopAllCoroutines();
				if (y<2)
				Reset();
			}
		}
	}
	
}
