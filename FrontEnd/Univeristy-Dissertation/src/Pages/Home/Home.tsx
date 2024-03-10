import { useEffect, useState } from "react";
import "./Home.css";
import { useNavigate } from "react-router-dom";
import mascot from "../../components/Images/Sloth-removebg-FixedBG.png";

function Home() {
  const [isLoading, setLoading] = useState<boolean>(true);
  const navigate = useNavigate();

  useEffect(() => {
    setLoading(false);
  }, []);

  const buttonNav = (page: string) => {
    navigate(page);
  };

  return (
    <>
      {isLoading ? (
        <div className="loading">Loading...</div>
      ) : (
        <>
          <div className="homeTitle">
            <h1>Home</h1>
          </div>
          <div className="homeContainer">
            <div className="mascotContainer">
              <img
                src={mascot}
                alt="Sloth holding laptop - The Application Mascot"
              />
            </div>

            <div className="buttonContainer">
              <div className="homeButtonContainer">
                <button
                  className="div1 homeButtons"
                  onClick={() => buttonNav("/sortingVisualiser")}
                >
                  Sorting Visualiser
                </button>
                <button
                  className="div2 homeButtons"
                  onClick={() => buttonNav("/profile")}
                >
                  My Profile
                </button>

                <button
                  className="div3 homeButtons"
                  onClick={() => buttonNav("/learningZone")}
                >
                  Learning Zone
                </button>
                <button
                  className="div4 homeButtons"
                  onClick={() => buttonNav("/testingZone")}
                >
                  Testing Zone
                </button>
              </div>
            </div>
          </div>
        </>
      )}
    </>
  );
}

export default Home;
