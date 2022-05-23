class GoogleMap {
    constructor() {
        this.init();
        this.getAllCities();
    }
    init = () => {
        google.maps.visualRefresh = true;
        const Moscow = new google.maps.LatLng(55.752622, 37.617567);
        const mapOptions = {
            zoom: 5,
            center: Moscow,
            mapTypeId: google.maps.MapTypeId.G_NORMAL_MAP
        };

        this.map = new google.maps.Map(document.getElementById("canvas"), mapOptions);

        const myLatlng = new google.maps.LatLng(55.752622, 37.617567);

        new google.maps.Marker({
            position: myLatlng,
            map: this.map,
        });

    }
    getAllCities = async () => {
        const response = await fetch("/api/cities");
        const cities = await response.json();
        cities.forEach(city => {
            const cityPosition = new google.maps.LatLng(city.coords.lat, city.coords.lon);

            const marker = new google.maps.Marker({
                position: cityPosition,
                map: this.map,
                title: city.name
            });
            // Для каждого объекта добавляем доп. информацию, выводимую в отдельном окне
            const infowindow = new google.maps.InfoWindow({
                content: `<div class='name'><h2>${city.name}</h2><div><h4>Население:
                    ${city.population}</h4></div><div><h4>Округ: ${city.district}</h4></div><div><h4>Область: ${city.subject}</h4></div></div>`
            });

            // обработчик нажатия на маркер объекта
            google.maps.event.addListener(marker, 'click', function () {
                infowindow.open(this.map, marker);
            });
            marker.setIcon('http://maps.google.com/mapfiles/ms/icons/red-dot.png')
        })

    }
}
new GoogleMap();