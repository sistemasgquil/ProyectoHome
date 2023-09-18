var articulos =[
{
nombre: "Bici",costo: 3000
},
{
    nombre: "TV",costo: 250
    },
    {
        nombre: "Libro",costo: 30
        },    
        {
            nombre: "Celular",costo: 100
            },
            {
                nombre: "Lapto",costo: 250
                },
                {
                    nombre: "Teclado",costo: 800
                    },
                    {
                        nombre: "Audifonos",costo: 500
                        },
];
var articulosfil=articulos.filter(function(articulo1)
{
    return articulo1.costo<=550
}
);
var articulosfil=articulos.map(function(articulo1)
{
    return articulo1.nombre
}
);

articulosfil
