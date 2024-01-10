import { useEffect, useState } from "react";
import "./Home.css";
import { useNavigate } from "react-router-dom";
import mascot from "../../components/Images/Sloth-removebg-FixedBG.png";
import FlexButton from "../../components/FlexButton/FlexButton";

function Home() {
  const [isLoading, setLoading] = useState<boolean>(true);
  const navigate = useNavigate();

  useEffect(() => {
    setLoading(false);
  }, []);

  const sortingVisualiserNav = () => {
    navigate("/sortingVisualiser");
  };

  const profileNav = () => {
    navigate("/profile");
  };

  return (
    <>
      {isLoading ? (
        <div className="loading">Loading...</div>
      ) : (
        <>
          <h1>Welcome to Alogrithm Visualiser!</h1>
          <div className="homeContainer">
            <div className="mascotContainer">
              <img src={mascot} alt="Sloth-Application Mascot" />
            </div>

            <div className="buttonContainer">
              <div className="buttonCardContainer">
                <button className="homeButtons" onClick={sortingVisualiserNav}>
                  Sorting Visualiser
                </button>
                <button className="homeButtons" onClick={profileNav}>
                  My Profile
                </button>
              </div>

              <div className="buttonCardContainer2">
                <button className="homeButtons" onClick={sortingVisualiserNav}>
                  Learning Zone
                </button>
                <button className="homeButtons" onClick={sortingVisualiserNav}>
                  Testing Zone
                </button>
                {/* <FlexButton></FlexButton> */}
              </div>
            </div>
          </div>
        </>
      )}
    </>
  );
}

export default Home;
