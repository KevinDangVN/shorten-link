import logo from "./logo.svg";
import "./App.css";
import axios from "axios";

const check = async () => {
  const response = await axios.get(
    "http://localhost:5000/api/linkdata/alllinks"
  );

  console.log(response);
};

check();

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;