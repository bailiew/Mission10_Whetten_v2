// Function to display the bowler list

import { useEffect, useState } from 'react';

// Interface for the bowler data
interface Bowler {
  bowlerID: number;
  bowlerFirstName: string;
  bowlerMiddleInit: string;
  bowlerLastName: string;
  teamName: string;
  bowlerAddress: string;
  bowlerCity: string;
  bowlerState: string;
  bowlerZip: string;
  bowlerPhoneNumber: string;
}

function BowlerList() {
  const [bowlers, setBowlers] = useState<Bowler[]>([]);

  // Fetch the bowler data from the API - and ensure it doesn't overwhelm the browser
  useEffect(() => {
    const fetchBowlers = async () => {
      try {
        const response = await fetch('http://localhost:5121/Bowler');
        const data = await response.json();
        setBowlers(data);
      } catch (error) {
        console.error('Error fetching bowlers:', error);
      }
    };
    fetchBowlers();
  }, []);

  return (
    <table>
      <thead>
        <tr>
          <th>Name</th>
          <th>Team</th>
          <th>Address</th>
          <th>City</th>
          <th>State</th>
          <th>Zip</th>
          <th>Phone</th>
        </tr>
      </thead>
      <tbody>
        {bowlers.map((bowler) => (
          <tr key={bowler.bowlerID}>
            <td>
              {bowler.bowlerFirstName}{' '}
              {bowler.bowlerMiddleInit ? bowler.bowlerMiddleInit + '. ' : ''}
              {bowler.bowlerLastName}
            </td>
            <td>{bowler.teamName}</td>
            <td>{bowler.bowlerAddress}</td>
            <td>{bowler.bowlerCity}</td>
            <td>{bowler.bowlerState}</td>
            <td>{bowler.bowlerZip}</td>
            <td>{bowler.bowlerPhoneNumber}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}

export default BowlerList;