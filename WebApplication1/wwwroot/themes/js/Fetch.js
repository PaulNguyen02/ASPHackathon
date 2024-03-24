async function getData() {
    dataResponse = fetch('https://api.openaq.org/v1/latest?limit=100&page=1&offset=0&sort=desc&radius=1000&country=VN&order_by=lastUpdated&dump_raw=false')   
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json(); // This returns a promise
        })
        .then(data => {
            let maxPM25 = 0;
            let minPM25 = 100;
            data.results.forEach(result => {                
                const city = result.city;
                const location = result.location;
                const pm25 = findPM25Measurement(result);
                const pm10 = findPM10Measurement(result);
                const co = findCOMeasurement(result);
                const so2 = findSO2Measurement(result);               
                populateTable(city, location, pm25, pm10, co, so2);
            });
            highlightRow();
        })
        .catch(error => {
            // Handle errors here
            console.error('There was a problem with the fetch operation:', error);
        });
}

async function Charting() {
    fetch('https://api.openaq.org/v1/latest?limit=100&page=1&offset=0&sort=desc&radius=1000&country=vn&order_by=lastUpdated&dump_raw=false')
        .then(response => response.json())
        .then(data => {
            const locations = data.results.map(location => ({
                name: location.location,
                value: location.measurements[0].value,
                unit: location.measurements[0].unit
            }));
            drawChart(locations);
        })
        .catch(error => console.error('Error:', error));
}

function findPM25Measurement(result) {
    // Assuming there's only one result and it contains measurements
    const measurements = result.measurements;
    return measurements.find(measurement => measurement.parameter === "pm25");
}

function findPM10Measurement(result) {
    // Assuming there's only one result and it contains measurements
    const measurements = result.measurements;
    return measurements.find(measurement => measurement.parameter === "pm10");
}

function findCOMeasurement(result) {
    // Assuming there's only one result and it contains measurements
    const measurements = result.measurements;
    return measurements.find(measurement => measurement.parameter === "co");
}

function findSO2Measurement(result) {
    // Assuming there's only one result and it contains measurements
    const measurements = result.measurements;
    return measurements.find(measurement => measurement.parameter === "so2");
}


function populateTable(city, location, pm25, pm10, co, so2) {
   
    const tableBody = document.getElementById('tableBody');
    const row = document.createElement('tr');
    row.innerHTML = `        
        <td>${city}</td>
        <td>${location}</td>
        <td>${pm10 ? pm10.value : 'N/A'}</td>
        <td>${pm25 ? pm25.value : 'N/A'}</td>
        <td>${co ? co.value : 'N/A'}</td>
        <td>${so2 ? so2.value : 'N/A'}</td>
    `;
    tableBody.appendChild(row);
}

function highlightRow() {
    var table = document.getElementById("dataTable");
    var rows = table.getElementsByTagName("tr");

    var minIndex = -1;
    var minValue = Infinity;
    var maxIndex = -1;
    var maxValue = 0;
    var avgIndex = -1;
    var avgValue = 0;
    for (var i = 1; i < rows.length; i++) { // Bắt đầu từ 1 để bỏ qua hàng tiêu đề
        var cells = rows[i].getElementsByTagName("td");
            var cellValue = parseInt(cells[2].innerText);
            if (!isNaN(cellValue) && cellValue < minValue) {
                minIndex = i;
                minValue = cellValue;
            }
            if (cellValue > maxValue) {
                maxIndex = i;
                maxValue = cellValue;
            }
            if (cellValue >= 13 && cellValue <= 35) {
                avgIndex = i;
                avgValue = cellValue
            }
    }
    rows[minIndex].style.backgroundColor = "springgreen";
    rows[maxIndex].style.backgroundColor = "tomato";
    rows[avgIndex].style.backgroundColor = "yellow";
    rows[minIndex].style.color = "white";
    rows[maxIndex].style.color = "white";
    rows[maxIndex].style.color = "black";
}


function getColorForValue(value) {
    if (value < 50) return '#4CAF50';
    else if (value < 100) return '#FFEB3B';
    else if (value < 150) return '#FF9800';
    else return '#F44336';
}

function drawChart(locations) {
    const container = document.getElementById('chart-container');
    container.innerHTML = ''; // Clear the container

    locations.forEach((location, index) => {
        const barContainer = document.createElement('div');
        barContainer.classList.add('bar-container');

        const label = document.createElement('div');
        label.classList.add('label');
        label.textContent = location.name;

        const bar = document.createElement('div');
        bar.classList.add('bar');
        const barWidth = location.value; // Giả định giá trị là đủ nhỏ để làm chiều rộng
        bar.style.width = `${barWidth * 3}px`; // Nhân với hệ số để tăng chiều rộng tương đối
        bar.style.backgroundColor = getColorForValue(location.value);
        bar.textContent = location.value + location.unit;

        barContainer.appendChild(label);
        barContainer.appendChild(bar);
        container.appendChild(barContainer);
    });
}

