using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DatosJuego {
    //YA NO MONOBEHAVIOUR, VA A RADICAR DE AFUERA. INDEPEND. A UNITY.
    // Start is called before the first frame update

    //niveles activos o inactivos.
    private bool[] nivelesMemoramaAnimales;
    private bool[] nivelesMemoramaMonstruos;
    private bool[] nivelesMemoramaRobots;

    // numerop de estrellas por nivel :
    private int[] estrellasMemoramaAnimales;
    private int[] estrellasMemoramaMonstruos;
    private int[] estrellasMemoramaRobots;

    //se juega por primera vez el juego o no :
    private bool juegoIniciadoPorPrimeraVez;

    //VAMOS A ASIGNAR LOS NIVELES COMO LAS ESTRELLAS, Y OBTENER LAS ESTRELLAS DE CADA UNO, LOS GETTER AND SETTERS, PARA FUTURAS PARTIDAS.
     //asignar niveles dispon en animales :
    public void AsignaNivelesMemoramaAnimales(bool[] nivelesMemoramaAnimales){
        this.nivelesMemoramaAnimales = nivelesMemoramaAnimales;
    }
    public bool[] ObtenNivelesMemoramaAnimales(){
        return this.nivelesMemoramaAnimales;
    }

    public void AsignaEstrellasMemoramaAnimales(int[] estrellasMemoramaAnimales){
        this.estrellasMemoramaAnimales = estrellasMemoramaAnimales;
    }
    public int[] ObtenEstrellasMemoramaAnimales(){
        return this.estrellasMemoramaAnimales;
    }





    public void AsignaNivelesMemoramaMonstruos(bool[] nivelesMemoramaMonstruos){
        this.nivelesMemoramaMonstruos = nivelesMemoramaMonstruos;
    }
    public bool[] ObtenNivelesMemoramaMonstruos(){
        return this.nivelesMemoramaMonstruos;
    }

    public void AsignaEstrellasMemoramaMonstruos(int[] estrellasMemoramaMonstruos){
        this.estrellasMemoramaMonstruos = estrellasMemoramaMonstruos;
    }
    public int[] ObtenEstrellasMemoramaMonstruos(){
        return this.estrellasMemoramaMonstruos;
    }







    public void AsignaNivelesMemoramaRobots(bool[] nivelesMemoramaRobots){
        this.nivelesMemoramaRobots = nivelesMemoramaRobots;
    }
    public bool[] ObtenNivelesMemoramaRobots(){
        return this.nivelesMemoramaRobots;
    }

    public void AsignaEstrellasMemoramaRobots(int[] estrellasMemoramaRobots){
        this.estrellasMemoramaRobots = estrellasMemoramaRobots;
    }
    public int[] ObtenEstrellasMemoramaRobots(){
        return this.estrellasMemoramaRobots;
    }





    public void AsignaJuegoIniciadoPorPrimeraVez(bool juegoIniciadoPorPrimeraVez){
        this.juegoIniciadoPorPrimeraVez = juegoIniciadoPorPrimeraVez;

    }

    public bool ObtenJuegoIniciadoPorPrimeraVez(){
        return juegoIniciadoPorPrimeraVez;
    }

    //Sabemos ahora los niveles desbloqueados, falta la de las estrellas : 

    

}
