import { IdentifyIndividual } from "./components/IdentifyIndividual";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { AirHistory } from "./components/AirHistory";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/identify-individual',
        element: <IdentifyIndividual />
    },
    {
        path: '/fetch-data',
        element: <FetchData />
    },
    {
        path: '/air-history',
        element: <AirHistory />
    }
];

export default AppRoutes;
