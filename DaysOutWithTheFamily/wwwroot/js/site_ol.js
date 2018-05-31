var map = new ol.Map({
    //Target is a tag with id 'map'
    target: 'map',
    layers: [
        new ol.layer.Tile({
            source: new ol.source.OSM() //This is an open street map
        })
    ],
    view: new ol.View({
        center: ol.proj.fromLonLat([-1.58, 54.775]),
        zoom: 15
    })
});