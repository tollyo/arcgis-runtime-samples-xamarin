﻿// Copyright 2015 Esri.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI;
using Xamarin.Forms;

namespace ArcGISRuntimeXamarin.Samples.RenderSimpleMarkers
{
    public partial class RenderSimpleMarkers : ContentPage
	{
		public RenderSimpleMarkers()
		{
            InitializeComponent ();

            Title = "Render simple markers";
            // Create the UI, setup the control references and execute initialization 
            Initialize();
        }

        private void Initialize()
        {
            // Create new Map with basemap
            var myMap = new Map(Basemap.CreateImagery());

            // Create initial map location and reuse the location for graphic
            var centralLocation = new MapPoint(-226773, 6550477, SpatialReferences.WebMercator);
            var initialViewpoint = new Viewpoint(centralLocation, 7500);

            // Set initial viewpoint
            myMap.InitialViewpoint = initialViewpoint;

            // Provide used Map to the MapView
            MyMapView.Map = myMap;

            // Create overlay to where graphics are shown
            var overlay = new GraphicsOverlay();

            // Add created overlay to the MapView
            MyMapView.GraphicsOverlays.Add(overlay);

            // Create a simple marker symbol
            var simpleSymbol = new SimpleMarkerSymbol()
            {
                Color = System.Drawing.Color.Red,
                Size = 10,
                Style = SimpleMarkerSymbolStyle.Circle
            };

            // Add a new graphic with a central point that was created earlier
            var graphicWithSymbol = new Graphic(centralLocation, simpleSymbol);
            overlay.Graphics.Add(graphicWithSymbol);
        }
    }
}