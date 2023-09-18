var miauto=
{
    marca:"Toyota",
    anio:55,
    modelo:"Corolla",
detalleauto: function()
{
    console.log('Auto ${this.modelo} ${this.anio}');
}
};
miauto.detalleauto();

function auto(marca,modelo,anio)
{
this.marca=marca;
this.modelo=modelo;
this.anio=anio;
}
// auto
var autonew=new auto("Tesla","Modelo Camargo",2023);
// autonew
var autonew2=new auto("Chevrolet","OK Camargo",2023);
autonew2