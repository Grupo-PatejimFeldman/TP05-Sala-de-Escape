using Newtonsoft.Json;
public class Juego{
    [JsonProperty]
    public int vidas{private set; get;} 
    public int habitacion{private set; get;} 
    [JsonProperty]
    Dictionary<int, string> respuestas = new Dictionary<int, string>();

    public void Inicializar(){

            respuestas.Add(1, "2118");
            respuestas.Add(2, "c");
            respuestas.Add(3, "2314");
            respuestas.Add(4, "celda");
            vidas = 3;
            habitacion = 1;
    }

    public int Respuesta(string respuesta){
        /* 0=no tiene vidas || 1=tiene vidas pero perdio una || 2=tiene vidas y acertó */
        int aux = 0;
        if (vidas != 0){
            if(respuesta == respuestas[habitacion]){
                habitacion++;
                aux=2;
            }else{
                vidas--;
                if(vidas!=0){
                    aux = 1;
                }
            }
        }
        return aux;
    }
    
}