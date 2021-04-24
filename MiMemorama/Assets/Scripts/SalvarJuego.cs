using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SalvarJuego : MonoBehaviour
{
    public DatosJuego datosJuego;

    public bool[] nivelesMemoramaAnimales;
    public bool[] nivelesMemoramaMonstruos;
    public bool[] nivelesMemoramaRobots;

    public int[] estrellasMemoramaAnimales;
    public int[] estrellasMemoramaMonstruos;
    public int[] estrellasMemoramaRobots;

    public bool juegoIniciadoPorPrimeraVez;

    void Awake() {
        IniciarJuego();
    }

    void IniciarJuego() {
        CargaDatosJuego();
    }

    void SalvaDatosJuego() {
        FileStream archivo = null;
        try {
            BinaryFormatter bf = new BinaryFormatter();
            archivo = File.Create(Application.persistentDataPath + "/GameData.dat");
            
            if(datosJuego != null){
                datosJuego.AsignaNivelesMemoramaAnimales(nivelesMemoramaAnimales);
                datosJuego.AsignaNivelesMemoramaMonstruos(nivelesMemoramaMonstruos);
                datosJuego.AsignaNivelesMemoramaRobots(nivelesMemoramaRobots);

                datosJuego.AsignaEstrellasMemoramaAnimales(estrellasMemoramaAnimales);
                datosJuego.AsignaEstrellasMemoramaMonstruos(estrellasMemoramaMonstruos); // falta en DatosJuego ...    AÑADIDA
                datosJuego.AsignaEstrellasMemoramaRobots(estrellasMemoramaRobots);  // falta en DatosJuego...    AÑADIDA

                datosJuego.AsignaJuegoIniciadoPorPrimeraVez(juegoIniciadoPorPrimeraVez);

                bf.Serialize(archivo, datosJuego);
            }


        } catch(Exception e){
            
        } finally {
            //cerrar el archivo, si es que fue abierto.
            if(archivo != null){
                archivo.Close();
            }
        }

    }

    void CargaDatosJuego() {
        FileStream archivo = null;
        try {
            BinaryFormatter bf = new BinaryFormatter();
            archivo = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);
            datosJuego = (DatosJuego)bf.Deserialize(archivo);
            if(datosJuego != null){
                nivelesMemoramaAnimales = datosJuego.ObtenNivelesMemoramaAnimales();
                nivelesMemoramaMonstruos = datosJuego.ObtenNivelesMemoramaMonstruos();
                nivelesMemoramaRobots = datosJuego.ObtenNivelesMemoramaRobots();

                estrellasMemoramaAnimales = datosJuego.ObtenEstrellasMemoramaAnimales();
                estrellasMemoramaMonstruos = datosJuego.ObtenEstrellasMemoramaMonstruos(); // falta en DatosJuego ...    AÑADIDA
                estrellasMemoramaRobots = datosJuego.ObtenEstrellasMemoramaRobots(); // falta en datos juego. ...    AÑADIDA
            }
        } catch(Exception e){

        } finally {
            //cerrar el archivo, si es que fue abierto.
            if(archivo != null){
                archivo.Close();
            }
        }
    }

}
