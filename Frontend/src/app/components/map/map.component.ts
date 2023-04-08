import { Component, OnInit, ChangeDetectorRef} from '@angular/core';
import * as mapboxgl from 'mapbox-gl';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {
  map: mapboxgl.Map;
  style = 'mapbox://styles/mapbox/streets-v11';
  lat = 26.3398;
  lng = -81.7787;

  constructor() {}

  ngOnInit() {
    mapboxgl as typeof mapboxgl;
    this.map = new mapboxgl.Map({
      accessToken:
        'pk.eyJ1Ijoib2F0YW1hbmNodWsiLCJhIjoiY2xnN3k1ODU2MHM3NjNnbzkzMnJ5amFrOSJ9.fUOEKrtONXbZfxQsn4YDlw',
      container: 'map',
      style: this.style,
      zoom: 2,
      center: [this.lng, this.lat],
    });

    this.map.addControl(new mapboxgl.NavigationControl());

    const customMarker = document.createElement('div');
    customMarker.style.backgroundImage = 'url(https://www.graphicpie.com/wp-content/uploads/2020/11/red-among-us-png.png)';
    customMarker.style.backgroundSize = 'cover';
    customMarker.style.backgroundPosition = 'center';
    customMarker.style.width = '27px';
    customMarker.style.height = '41px';

    new mapboxgl.Marker(customMarker)
      .setLngLat([30.5, 50.5])
      .addTo(this.map);
  }
}
